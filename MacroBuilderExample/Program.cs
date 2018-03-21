using Tekla.Structures;

namespace MacroBuilderExample
{
	public class Program
	{
		static void Main(string[] args)
		{
			if(!TeklaStructures.Connect()) return;

			var macroBuilderExample = new MacroBuilderExample();

			macroBuilderExample.CreateViewOfAllModelObject();

			macroBuilderExample.OpenDrawingListOfColumns();
		}
	}

	public class MacroBuilderExample
	{
		public void CreateViewOfAllModelObject()
		{
			var macroBuilder = new MacroBuilder();

			//create view of all model objects
			macroBuilder.Callback("acmdSelectAll", "", "main_frame");
			macroBuilder.Callback("acmdCreateViewBySelectedObjectsExtrema", "", "View_01 window_1");
			macroBuilder.Callback("acmd_set_view_representation", "rendered_joint", "main_frame");
			macroBuilder.Callback("acmd_set_view_representation", "rendered", "main_frame");

			macroBuilder.Run();

			//recorded macro code for reference

			//akit.Callback("acmdSelectAll", "", "main_frame");
			//akit.Callback("acmdCreateViewBySelectedObjectsExtrema", "", "View_02 window_1");
			//akit.Callback("acmd_set_view_representation", "rendered", "main_frame");
			//akit.Callback("acmd_set_view_representation", "rendered_joint", "main_frame");
		}

		public void OpenDrawingListOfColumns()
		{
			var macroBuilder = new MacroBuilder();

			//open drawing list and show columns
			macroBuilder.ValueChange("main_frame", "sel_all", "0");
			macroBuilder.ValueChange("main_frame", "sel_all", "1");
			macroBuilder.ValueChange("main_frame", "sel_filter", "Steel_Column");
			macroBuilder.Callback("acmdSelectAll", "", "main_frame");
			macroBuilder.Callback("gdr_menu_select_active_draw", "", "main_frame");
			macroBuilder.PushButton("dia_draw_display_all", "Drawing_selection");
			macroBuilder.PushButton("dia_draw_filter_by_parts", "Drawing_selection");

			macroBuilder.Run();

			//recorded macro code for reference

			//akit.ValueChange("main_frame", "sel_all", "0");
			//akit.ValueChange("main_frame", "sel_all", "1");
			//akit.ValueChange("main_frame", "sel_filter", "Steel_Column");
			//akit.Callback("acmdSelectAll", "", "main_frame");
			//akit.Callback("gdr_menu_select_active_draw", "", "main_frame");
			//akit.PushButton("dia_draw_display_all", "Drawing_selection");
			//akit.PushButton("dia_draw_filter_by_parts", "Drawing_selection");
		}
	}
}
