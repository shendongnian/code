    public static MvcHtmlString DropDownListFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression,
                                                   IEnumerable<SelectListItem> selectList, string selectedValue, string optionLabel, object htmlAttributes)
        {
            Func<TModel, TValue> method = expression.Compile();
            string value = method(helper.ViewData.Model) as string;
            
            if (string.IsNullOrEmpty(value) && selectList != null)
            {
                var selectListList = selectList.ToList();
                var selectedItem = selectListList.FirstOrDefault(s => s.Selected);
                if (selectedItem == null)
                {
                    var itemToSelect = selectListList.FirstOrDefault(w => w.Value == selectedValue);
                    if (itemToSelect != null)
                    {
                        itemToSelect.Selected = true;
                    }
                }
                return helper.DropDownListFor(expression, selectListList, optionLabel, htmlAttributes);
            }
            return helper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes);
        }
