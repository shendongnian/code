    public string RenderContents()
	{
		StringWriter writer = new StringWriter();
		HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
		foreach (var control in Contents)
		{
			control.RenderControl(htmlWriter);
		}
		return writer.ToString();
	}
