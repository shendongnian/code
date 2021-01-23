    public static class HtmlHelperExtensions
    {        
        public static IHtmlString EditorDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            var dropDown = SelectExtensions.DropDownListFor(htmlHelper, expression, selectList, optionLabel);
            var model = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
            if (model == null)
            {
                return dropDown;
            }
    
            var dropDownWithSelect = dropDown.ToString().Replace("value=\"" + model.ToString() + "\"", "value=\"" + model.ToString() + "\" selected");
            return new MvcHtmlString(dropDownWithSelect);
        }
    }
