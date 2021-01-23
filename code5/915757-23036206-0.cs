	public static MvcHtmlString LabelForX<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string requiredText = "required", string innerText = "*" )
	{
		ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
		string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
		string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
		if (String.IsNullOrEmpty(labelText))
		{
			return MvcHtmlString.Empty;
		}
		var tag = new TagBuilder("label");
		tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
		tag.SetInnerText(labelText);
		if (metadata.IsRequired)
		{
			var span = new TagBuilder("abbr");
			span.Attributes.Add("title", requiredText);
			span.Attributes.Add("class", "labelRequired");
			span.SetInnerText(innerText);
			tag.Attributes.Add("class", "labelRequired");
			tag.InnerHtml = span.ToString(TagRenderMode.Normal) + "&nbsp;" + labelText;
		}
		return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal)); 
	}
