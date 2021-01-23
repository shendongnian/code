    using (var da = new SqlDataAdapter("SELECT * FROM mytable", "connection string"))
    {
        var table = new DataTable();
        da.Fill(table);
    }
        foreach(DataRow row in table.Rows){
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes.Add("data-trait-id", row["TraitID"].ToString());
            HtmlAnchor a = new HtmlAnchor();
            a.Attributes.Add("data-trait-id", row["TraitID"].ToString());
            HtmlGenericControl span1 = new HtmlGenericControl("span");
            span1.Attributes.Add("class", "name");
            span1.InnerText = row["Name"].ToString();
            a.Controls.Add(span1);
            HtmlGenericControl span2 = new HtmlGenericControl("span");
            span2.Attributes.Add("class", "count");
            span2.InnerText = row["Count"].ToString();
            a.Controls.Add(span2);
            li.Controls.Add(a);
            ulSpecialty_selector.Controls.Add(li);
        }
