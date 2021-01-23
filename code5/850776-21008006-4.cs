    public static MvcHtmlString LabelledTextBoxFor2<TModel, TResult>(this HtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            ExpressionType type = expression.Body.NodeType;
            if (type == ExpressionType.MemberAccess)
            {
                var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
                var displayName = metadata.DisplayName;
                var propName = metadata.PropertyName;
                StringBuilder sb = new StringBuilder();
                
                sb.Append("<div class=\"form-group\">");
                sb.AppendFormat("<label for=\"{0}\">{1}</label>", propName, displayName);
                sb.AppendFormat(
                            "<input type=\"email\" class=\"form-control\" id=\"{0}\" placeholder=\"Enter email\">",
                            propName);
                 sb.Append("</div>");
                 return MvcHtmlString.Create(sb.ToString());
            }
 
            return MvcHtmlString.Create("");
        }
