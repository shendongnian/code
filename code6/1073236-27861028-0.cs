	public abstract class CustomWebViewPage: WebViewPage
	{
		public override void ExecutePageHierarchy()
		{
			var layoutReferenceMarkup = @"<script type=""text/html"" data-layout-id=""" + TemplateInfo.VirtualPath + @"""></script>";
			
			base.ExecutePageHierarchy();
			string output = Output.ToString();
			//if the body tag is present the script tag should be injected into it, otherwise simply append
			if (output.Contains("</body>"))
			{
				Response.Clear();
				Response.Write(output.Replace("</body>", layoutReferenceMarkup+"</body>"));
				Response.End();
			}
			else
			{
				Output.Write(layoutReferenceMarkup);
			}
		}
	}
	public abstract class CustomWebViewPage<TModel>: CustomWebViewPage
	{
	}
