     public static HtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectListItems, RadioButtonListLayout layout)
            {
                var sb = new StringBuilder();
    
                foreach (var item in selectListItems)
                {
                    var itemId = string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}_{1}",
                        helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)),
                        item.Value);
    
                    var itemHtml = string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} <label for=\"{1}\">{2}</label>",
                        helper.RadioButtonFor(expression, item.Value, new { id = itemId }),
                        itemId,
                        item.Text);
    
                    if (layout == RadioButtonListLayout.Horizontal)
                    {
                        sb.Append("<span class=\"radiobuttonlist-horizontal\">");
                        sb.Append(itemHtml);
                        sb.AppendLine("</span>");
                    }
                    else
                    {
                        sb.Append("<div class=\"radiobuttonlist-vertical\">");
                        sb.Append(itemHtml);
                        sb.AppendLine("</div>");
                    }
                }
    
                return new HtmlString(sb.ToString());
            }
