        HtmlGenericControl ul = new HtmlGenericControl("ul");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", "#");
            anchor.InnerText = ds.Tables[0].Rows[i][0].ToString();
            li.Controls.Add(anchor);
            ul.Controls.Add(li);
            if (ds.Tables[0].Rows[i][2] != null)
            {
                HtmlGenericControl ili = new HtmlGenericControl("li");
                ul.Controls.Add(ili);
                HtmlGenericControl ianchor = new HtmlGenericControl("a");
                ianchor.Attributes.Add("href","page.aspx");
                ianchor.InnerText = ds.Tables[0].Rows[i][0].ToString();
                ili.Controls.Add(ianchor);
                HtmlGenericControl ul2 = new HtmlGenericControl("ul");
                ili.Controls.Add(ul2);
                param = ds.Tables[0].Rows[i][2].ToString();
                LevelControl(param);
            }
            ul.Controls.Add(li);
                      
        }
        tabs.Controls.Add(ul); 
