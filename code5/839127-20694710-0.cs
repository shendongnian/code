    string strNewPath = SavePath + NewFileName + Path.GetExtension(UploadedFile.FileName);
    
    if (System.IO.File.Exists(strNewPath)) {
      System.IO.File.Move(strNewPath, SavePath + NewFileName + DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss") + Path.GetExtension(UploadedFile.FileName));
      UploadedFile.SaveAs(strNewPath);
    }
    else {
      UploadedFile.SaveAs(strNewPath);
    }
    
    using (db) {
      File NewFile = new File() {
        FileName = NewFileName + Path.GetExtension(UploadedFile.FileName),
        ContentType = UploadedFile.ContentType
      };
    
      db.Files.Add(NewFile);
      db.SaveChanges();
      
      return NewFile.ID;
    }
