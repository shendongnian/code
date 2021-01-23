    public static class CustomHtmlHelper {
        
        public static MvcHtmlString MyFieldBox<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, String title) {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"field-box\">");
            sb.AppendLine("<div class=\"field-box">\");
            sb.AppendLine("<label>{0}</label>", title);
            sb.AppendLine("<div class=\"col-md-7\">");
            sb.AppendLine( htmlHelper.TextBoxFor( expression, new { @class = "form-control inline-input" }) );
            sb.AppendLine("</div>");
            sb.AppendLine( htmlHelper.ValidationMessageFor( expression );
            sb.AppendLine("</div>");
            return new MvcHtmlString( sb.ToString() );
        }
        
    }
