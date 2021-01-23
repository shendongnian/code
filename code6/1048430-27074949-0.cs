    public static MvcHtmlString XCheckBox<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool?>> expression, bool isReadOnly, int labelColumns, int controlColumns, object htmlAttributes)
    {
      ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
      string label = metaData.GetDisplayName();
      string name = ExpressionHelper.GetExpressionText(expression);
      StringBuilder html = new StringBuilder();      
      if (isReadOnly)
      {
        html.Append(ReadonlyLabelCell(label, labelColumns));
        html.Append(ReadonlyValueCell((bool?)metaData.Model, controlColumns));
      }
      else
      {
        html.Append(LabelCell(label, name, labelColumns));
        html.Append(ControlCell(name, (bool?)metaData.Model, controlColumns, htmlAttributes));
      }     
      return MvcHtmlString.Create(html.ToString());
    }
    private static string ReadonlyLabelCell(string label, int colSpan)
    {
      TagBuilder span = new TagBuilder("span");
      span.InnerHtml = label;
      TagBuilder cell = new TagBuilder("td");
      cell.AddCssClass("label");
      cell.MergeAttribute("colspan", colSpan.ToString());
      cell.InnerHtml = span.ToString();
      return cell.ToString();
    }
    private static string ReadonlyValueCell(bool? value, int colSpan)
    {
      TagBuilder span = new TagBuilder("span");
      span.InnerHtml = value.HasValue ? value.Value ? "Yes" : "No" : "Not set";
      TagBuilder cell = new TagBuilder("td");
      cell.AddCssClass("readonly"); // added class for styling
      cell.MergeAttribute("colspan", colSpan.ToString());
      cell.InnerHtml = span.ToString();
      return cell.ToString();
    }
    private static string LabelCell(string labelText, string controlName, int colSpan)
    {
      TagBuilder label = new TagBuilder("label");
      label.MergeAttribute("for", controlName);
      label.InnerHtml = labelText;
      TagBuilder cell = new TagBuilder("td");
      cell.AddCssClass("label");
      cell.MergeAttribute("colspan", colSpan.ToString());
      cell.InnerHtml = label.ToString();
      return cell.ToString();
    }
    private static string ControlCell(string controlName, bool? value, int colSpan, object htmlAttributes)
    {
      StringBuilder html = new StringBuilder();
      TagBuilder option = new TagBuilder("option");
      option.MergeAttribute("value", string.Empty);
      option.InnerHtml = "Not set";
      html.Append(option.ToString());
      option = new TagBuilder("option");
      option.MergeAttribute("value", "true");
      if (value.HasValue && value.Value)
      {
        option.MergeAttribute("selected", "selected");
      }
      option.InnerHtml = "Yes";
      html.Append(option.ToString());
      option = new TagBuilder("option");
      option.MergeAttribute("value", "false");
      if (value.HasValue && !value.Value)
      {
        option.MergeAttribute("selected", "selected");
      }
      option.InnerHtml = "No";
      html.Append(option.ToString());
      TagBuilder select = new TagBuilder("select");
      select.MergeAttribute("name", controlName);
      select.MergeAttribute("id", HtmlHelper.GenerateIdFromName(controlName));
      select.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
      select.InnerHtml = html.ToString();
      TagBuilder cell = new TagBuilder("td");
      cell.AddCssClass("controlcell");
      cell.MergeAttribute("colspan", colSpan.ToString());
      cell.InnerHtml = select.ToString();
      return cell.ToString();
    }
