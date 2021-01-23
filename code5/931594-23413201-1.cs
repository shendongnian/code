	protected override void Render(HtmlTextWriter writer)
	{
		this.CacheControl.RenderHeader(this.Page);
		using (HtmlTextWriter htmlwriter = new HtmlTextWriter(new StringWriter()))
		{
			base.Render(htmlwriter);
			string html = htmlwriter.InnerWriter.ToString();
			/* To support unicode \w and \p{X} variables inside of asp:RegularExpressionValidator controls on client side.
			 * This can actually only work when your website reffers to the UnicodeRegex.js that includes 
			 * the initialisation of the global u and w variable.
			 * This also only work as long as \w and \p{X} are inside of corner brackets [] in your expressions.
			 * Do not use \W and \P{X} with it, instead negate it with ^.
			 */
			html = Regex.Replace(html, @"(?<=\.validationexpression = "".*?)\\\\w(?=.*?(?<!\\)"")", "\" + w + \"");
			html = Regex.Replace(html, @"(?<=\.validationexpression = "".*?)\\\\p\{([a-zA-Z]){1,2}\}(?=.*?(?<!\\)"")", "\" + u.$1 + \"");
			writer.Write(html);
		}
	}
