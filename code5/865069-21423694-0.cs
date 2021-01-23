    public static class HtmlHelpers
    {
        public static IHtmlString ModelTableForm(this HtmlHelper html, object model)
        {
            StringBuilder modelTable = new StringBuilder();
            modelTable.Append("<table>");
            modelTable.AppendFormat("<caption>{0}</caption>", model.GetType().Name);
            modelTable.Append("<tbody>");
    
            foreach (var property in model.GetType().GetProperties())
                modelTable.Append(addModelRow(property.Name, property.GetValue(model, null)));
            modelTable.Append("</tbody>");
            modelTable.Append("</table>");
            return html.Raw(modelTable.ToString());
        }
    
        static string addModelRow(string name, object value)
        {
            StringBuilder row = new StringBuilder();
            row.Append("<tr>");
            row.AppendFormat("<td>{0}</td>", name);
            row.AppendFormat("<td>{0}</td>", value);
            row.Append("</tr>");
            return row.ToString();
        }
    }
