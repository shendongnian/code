           public static MvcHtmlString ExtendedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
            {
                return SelectInternal(htmlHelper, optionLabel, ExpressionHelper.GetExpressionText(expression), selectList, false /* allowMultiple */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }
            private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes)
            {
                string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
                if (String.IsNullOrEmpty(fullName))
                    throw new ArgumentException("No name");
    
                if (selectList == null)
                    throw new ArgumentException("No selectlist");
    
                object defaultValue = null;
    
                // If we haven't already used ViewData to get the entire list of items then we need to
                // use the ViewData-supplied value before using the parameter-supplied value.
                if (defaultValue == null)
                    defaultValue = htmlHelper.ViewData.Eval(fullName);
    
                if (defaultValue != null)
                {
                    IEnumerable defaultValues = (allowMultiple) ? defaultValue as IEnumerable : new[] { defaultValue };
                    IEnumerable<string> values = from object value in defaultValues select Convert.ToString(value, CultureInfo.CurrentCulture);
                    HashSet<string> selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
                    List<SelectListItem> newSelectList = new List<SelectListItem>();
    
                    foreach (SelectListItem item in selectList)
                    {
                        item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                        newSelectList.Add(item);
                    }
                    selectList = newSelectList;
                }
    
                // Convert each ListItem to an <option> tag
                StringBuilder listItemBuilder = new StringBuilder();
    
                // Make optionLabel the first item that gets rendered.
                if (optionLabel != null)
                    listItemBuilder.Append(ListItemToOption(new SelectListItem() { Text = optionLabel, Value = String.Empty, Selected = false }));
    
                foreach (SelectListItem item in selectList)
                {                
                    listItemBuilder.Append(ListItemToOption(item));
                }
    
                TagBuilder tagBuilder = new TagBuilder("select")
                {
                    InnerHtml = listItemBuilder.ToString()
                };
                tagBuilder.MergeAttributes(htmlAttributes);
                tagBuilder.MergeAttribute("name", fullName, true /* replaceExisting */);
                tagBuilder.GenerateId(fullName);
                if (allowMultiple)
                    tagBuilder.MergeAttribute("multiple", "multiple");
    
                // If there are any errors for a named field, we add the css attribute.
                ModelState modelState;
                if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
                {
                    if (modelState.Errors.Count > 0)
                    {
                        tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                    }
                }
    
                tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));
    
                return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
            }
    
            internal static string ListItemToOption(SelectListItem item)
            {
                TagBuilder builder = new TagBuilder("option")
                {
                    InnerHtml = HttpUtility.HtmlEncode(item.Text)
                };
                if (item.Value != null)
                {
                    builder.Attributes["value"] = item.Value;
                    //builder.Attributes["style"] = "background-color:Gray;";
                }
                if (item.Selected)
                {
                    builder.Attributes["selected"] = "selected";
                }
               // builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(item.htmlAttributes));
    
                TagBuilder OptGroup = new TagBuilder("optgroup ")
                {
                    InnerHtml = builder.ToString(TagRenderMode.Normal)
                };
    
                OptGroup.Attributes["style"] = "display:none;font-family:" + item.Value + ";";
    
                return OptGroup.ToString(TagRenderMode.Normal);
            }
