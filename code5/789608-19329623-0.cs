    protected void Page_Load(object sender, EventArgs e)
    {
        ....
    
        if (reader.Read())
        {
            billedeID.Text = reader["Id"].ToString();
            billedenavn.Text = reader["imgnavn"].ToString();
            ViewState["imgnavn"] = reader["imgnavn"].ToString();
        }
    
        ....
    }
    protected void sletBtn_Click(object sender, EventArgs e)
    {
        try
        {
  
            string imageName = ViewState["imgnavn"].ToString();    
    
            // slet Originalfilen i image/upload/Original/ mappen
            File.Delete(Server.MapPath("~/upload/originals/" + imageName));
    
            // Slet Thumbsfilen i /Images/Upload/Thumbs/
            File.Delete(Server.MapPath("~/upload/thumbs/" + imageName));
    
            // Slet Resized_Original i /Images/Upload/Resized_Original/ mappen
            File.Delete(Server.MapPath("~/upload/originalsResized/" + imageName));
    
            ...
        }
    
        ...
    }
