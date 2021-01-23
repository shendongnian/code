	private bool HasContent(Control ctrl)
	{
		var sb = new System.Text.StringBuilder();
		using (var sw = new System.IO.StringWriter(sb)) 
		{
			using(var tw = new HtmlTextWriter(sw))
			{
				ctrl.RenderControl(tw);
			}
		}
		var output = sb.ToString().Trim();
		return !String.IsNullOrEmpty(output);
	}
	protected void Page_PreRender(object sender, EventArgs e)
	{
		var placeholder = Master.FindControl("FeaturedContent");
		var hasContent = HasContent(placeholder);
	}
