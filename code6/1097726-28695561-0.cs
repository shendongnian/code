    using (ZipFile zip = new ZipFile())
    {  
    
     foreach(var name in ListOfPastPapers)
     {
        if(System.IO.File.Exists(name))
        {
           zip.AddFiles(filePath,"PastPapers");                    
           zip.Save(Response.OutputStream);
           Response.Close();
         }
       }
    }
