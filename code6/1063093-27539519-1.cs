            while (dr.Read())
            {       
                status += dr["Status"].ToString();
                name += dr["name"].ToString();
            }
            System.Web.UI.HtmlControls.HtmlGenericControl div = new 
                   System.Web.UI.HtmlControls.HtmlGenericControl("div");
            container.Controls.Add(div);
            Label nameLabel = new Label();
            nameLabel.Text = name;
            div.Controls.Add(nameLabel);
            Label statusLabel = new Label();
            statusLabel.Text = status;
            div.Controls.Add(statusLabel);
