    DataTable dt = getData(); //Insert your datasource here
        HtmlAnchor a = new HtmlAnchor();
        foreach(DataRow row in dt.Rows){
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.Attributes.Add("class", "name");
            span.InnerText = row["Name"];
            a.Controls.Add(span);
        }
