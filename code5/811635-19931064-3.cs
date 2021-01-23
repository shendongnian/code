    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["preview"] == "1" && !string.IsNullOrEmpty(Request.QueryString["fileId"]))
        {
              var fileId = Request.QueryString["fileId"];
              var fileContents = (byte[])Session["fileContents_" + fileId];
              var fileContentType = (string)Session["fileContentType_" + fileId];
              
              // To clear the current uploaded file, prepare to upload other files
              if (fileContents != null)
              {
                    Response.Clear();
                    Response.ContentType = fileContentType;
                    Response.BinaryWrite(fileContents);
                    Response.End();
              }
          }
      }
         
       
