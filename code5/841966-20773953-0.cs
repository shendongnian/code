    public static class ControlExtension
	{
		public static void RemoveCssClass(this HtmlControl control, string cssClassName)
		{
			var val = control.Attributes["class"];
			val = val.Replace(cssClassName, string.Empty);
			control.Attributes["class"] = val;
		}
	}
