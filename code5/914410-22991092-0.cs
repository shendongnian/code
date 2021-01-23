    public static MvcHtmlString TableRowFor<T>(this HtmlHelper helper, T obj)
    {
        string controller = obj.GetType().BaseType.Name;
        string id = obj.GetType().GetProperty("id").GetValue(obj).ToString();
        StringBuilder sb = new StringBuilder("<tr>");
        sb.Append("<td>");
        sb.Append("<a href='" + controller + "/Edit/" + id + "'><img src='/Images/edit-icon.png' /></a>");
        sb.Append("<a href='" + controller + "/Details/" + id + "'><img src='/Images/details-icon.png' /></a>");
        sb.Append("<a href='" + controller + "/Delete/" + id + "'><img src='/Images/delete-icon.png' /></a>");
        sb.Append("</td>");
        List<string> referencePropertyList = GetReferenceProperies<T>(new NameOfDB()).ToList();
        foreach (var property in obj.GetType().GetProperties())
        {
            //If statement below filters out the two virtual properties(plc, verbruik) of the schakeling class(as said, generated with EF), somewhat ugly but it works, better suggestions are welcome..
            if ((!property.PropertyType.Name.ToLower().Contains("icollection")) && (property.PropertyType.CustomAttributes.Count() != 0))
            {
                sb.Append("<td>");
                //if property is foreign key
                if (referencePropertyList != null && property.Name.Length >= 3 && referencePropertyList.Contains(property.Name.Substring(0, property.Name.Length - 3)))
                    sb.Append("<a href='" + property.Name.Substring(0, property.Name.Length - 3 ) + "/Details/" + property.GetValue(obj) + "'>" + property.GetValue(obj) + "</a>");
                else
                    sb.Append(property.GetValue(obj));
                sb.Append("</td>");
            }
        }
        sb.Append("</tr>");
        return new MvcHtmlString(sb.ToString());
    }
