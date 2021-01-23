    public static MvcHtmlString BootstrapCheckBoxFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression)
    {
      TagBuilder innerContainer = new TagBuilder("div");
      innerContainer.AddCssClass("col-sm-5");
      innerContainer.InnerHtml = helper.CheckBoxFor(expression, new {@class = "form-control"}).ToString();
      StringBuilder html = new StringBuilder();
      html.Append(helper.LabelFor(expression, new {@class = "col-sm-3 control-label"}));
      html.Append(innerContainer.ToString());
      TagBuilder outerContainer = new TagBuilder("div");
      outerContainer.AddCssClass("form-group");
      outerContainer.InnerHtml = html.ToString();
      return MvcHtmlString.Create(outerContainer.ToString());
    }
