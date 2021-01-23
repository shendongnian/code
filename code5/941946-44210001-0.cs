	public static void HideArrowMargin(this ToolStripDropDownItem tsddi)
	{
		tsddi.DropDown.GetType().GetField("ArrowPadding", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, new Padding(0, 0, -14, 0));
	}
	public static void HideImageMargin(this ToolStripDropDownItem tsddi)
	{
		((ToolStripDropDownMenu)tsddi.DropDown).ShowImageMargin = false;
	}
