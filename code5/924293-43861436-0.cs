    public class HelperExtentions
    {
        public static MvcHtmlString DefaultRenderer<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, LocationModel model, SelectList selectList, object htmlAttributes)
        {
            var sb = new StringBuilder();
    
            var countryCode = string.IsNullOrEmpty(model.CountryCode):"":model.CountryCode;
            var dtp = "";
            if (countryCode.Equals("CA") || countryCode.Equals("US"))
            {
                dtp = htmlHelper.DropDownListFor(expression, selectList, htmlAttributes);
            }
            else
            {
                dtp = htmlHelper.TextBoxFor(expression, htmlAttributes).ToHtmlString();
            }
            sb.AppendFormat(dtp);
            return MvcHtmlString.Create(sb.ToString());
        }
    
    }
