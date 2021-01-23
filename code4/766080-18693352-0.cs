    protected void AsyncFileUpload1_UploadedComplete
    	(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
      
      if (AsyncFileUpload1.HasFile)
      {
        string strPath = MapPath("~/UploaddedFiles/") + Path.GetFileName(e.filename);
        AsyncFileUpload1.SaveAs(strPath);
         ...
         ...
         GrdMadarek.DataBind();
         UpdatePanel1.Update();
          
      }
    }
