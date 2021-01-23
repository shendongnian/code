    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Import(HttpPostedFileBase UploadFile, FormCollection collection)
    {
      // Do some initial file validation - removed
    
      string filePath = Path.Combine(EDTConstants.NETWORK_SHARE_PATH, Path.GetFileName(UploadFile.FileName));
    
      try
      {
        // Do some validation on the file that was uploaded.
        if (UploadFile == null)
        {
          // return an error here - there was no file selected.
        }
    
        if (UploadFile.ContentLength == 0)
        {
          // return an error here - the file is empty.
        }
    
        if (!filePath.ToUpper().EndsWith("XLS") && !filePath.ToUpper().EndsWith("XLSX"))
        {
          // return an error here - the file extension is not supported.
        }
    
        // Things are good so far.  Save the file so we can read from it.
        UploadFile.SaveAs(filePath);
        DataSet fileDS = new DataSet();
        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
        using (OleDbConnection conn = new OleDbConnection(connString))
        {
          conn.Open();
          using (DataTable dtExcel = conn.GetSchema("Tables"))
          {
            // ... a bunch of code removed ...
          }
          conn.Close();
        }
    
      }
      catch (Exception e)
      {
        // Unexpected error
        EDTUtils.LogErrorMessage(EDTConstants.TABLE_IMPORT, User.Identity.Name, e);
        ViewData[EDTConstants.SSN_VD_ERROR_MSG] = EDTConstants.EM_UNEXPECTED + System.Environment.NewLine + e.Message;
        ViewData[EDTConstants.VIEWDATA_FILE] = UploadFile.FileName;
        
        
      }
      finally
      {
    	CloseFile(filePath);
      }
      //you were only returning in the CATCH ? 
      return View(tab);
      
    }
