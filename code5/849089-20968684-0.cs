    FileInfo localFile;
    FileInfo pdfFile;
    try{
        SaveTextFile(localFile);
        SavePDFFile(pdfFile);
       
        SendEmail();
    }catch{
       // something went wrong...
       // you can remove extra try catch
       // but you might get security related
       // exceptions
       try{
          if(localFile.Exists) localFile.Delete();
          if(pdfFile.Exists) pdfFile.Delete();
       }catch{}
    }
