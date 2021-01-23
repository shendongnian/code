    cmd.CommandText = "SELECT Name,Status FROM [ProfileStatusPhoto] WHERE Email = @Email";
    cmd.Parameters.AddWithValue("@Email", Session["Email"].ToString());
    while (dr.Read())
    {
        System.Web.UI.HtmlControls.HtmlGenericControl div = 
        new System.Web.UI.HtmlControls.HtmlGenericControl("div");    
        Label nameLabel = new Label();
        status += dr["Status"].ToString();
        name += dr["name"].ToString();
        nameLabel.Text = name;
        Label statusLabel = new Label();
        statusLabel.Text = status;
       div.Controls.Add(nameLabel);
       div.Controls.Add(statusLabel);
       container.Controls.Add(div);
    }
