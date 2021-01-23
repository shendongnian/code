    ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
    string name = ExpressionHelper.GetExpressionText(expression);
    if (isHidden)
    {
      TagBuilder input = new Tagbuilder("input");
      input.MergeAttribute("type", "hidden");
      input.MergeAttribute("name", name);
      input.MergeAttribute("value", metaData.Model.ToString(helper.ViewContext.HttpContext.UserContext().CultureInfo));
      return MvcHtmlString.Create(input.ToString());
    }
    else
    {
      ....
