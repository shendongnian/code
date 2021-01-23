    public static MvcHtmlString ReadOnlyCheckBoxIf<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool>> expression, bool isReadOnly)
    {
      if (isReadOnly)
      {
        // If you want to 'visually' render a checkbox (otherwise just render a div with "YES" or "NO")
        ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        StringBuilder html = new StringBuilder();
        // Add a hidden input for postback
        html.Append(InputExtensions.HiddenFor(helper, expression).ToString());
        // Add a visual checkbox without name so it does not post back
        TagBuilder checkbox = new TagBuilder("input");
        checkbox.MergeAttribute("type", "checkbox");
        checkbox.MergeAttribute("disabled", "disabled");
        if ((bool)metaData.Model)
        {
          checkbox.MergeAttribute("checked", "checked");
        }
        html.Append(checkbox.ToString());
        return MvcHtmlString.Create(html.ToString());
      }
      else
      {
        // return normal checkbox
        return InputExtensions.CheckBoxFor(helper, expression);
      }
    }
