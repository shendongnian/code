    protected void SqlDataSourceAddNews_Inserted(object sender, EventArgs e)
    {
    
       string strId = e.Command>parameters("@Id").Value.ToString();
       FileUpload fu2 = (FileUpload)ListViewNews.InsertItem.FindControl("FileUpload2");
       if (fu2.HasFile)
       {
         string aut = strID + ".jpg";               
         fu2.SaveAs(Server.MapPath("~/images/NewsPhotos/" + aut));               
       }  
    }
