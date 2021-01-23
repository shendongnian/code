    public static MvcHtmlString LabelledTextBoxFor<TModel, TResult>(this HtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
    {
        ExpressionType type = expression.Body.NodeType;
        if (type == ExpressionType.MemberAccess)
        {
           MemberExpression memberExpression = (MemberExpression) expression.Body;
           var propName = memberExpression.Member.Name;
           var member = memberExpression.Member as PropertyInfo;
           var attributes = member.GetCustomAttributes();
           StringBuilder sb = new StringBuilder();
           foreach (var attribute in attributes)
           {
               if (attribute is DisplayAttribute)
               {
                   DisplayAttribute d = attribute as DisplayAttribute;
                   var displayName = d.Name;
                   sb.Append("<div class=\"form-group\">");
                   sb.AppendFormat("<label for=\"{0}\">{1}</label>", propName, displayName);
                   sb.AppendFormat(
                            "<input type=\"email\" class=\"form-control\" id=\"{0}\" placeholder=\"Enter email\">",
                            propName);
                   sb.Append("</div>");
                   return MvcHtmlString.Create(sb.ToString());
                 }
             }
         }
           return MvcHtmlString.Create("");
     }
