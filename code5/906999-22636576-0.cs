     XDocument doc; // out os using scope
     using (IsolatedStorageFileStream stream = isf.OpenFile("inventories.xml", 
               FileMode.Open, FileAccess.Read))
      {
            XDocument doc = XDocument.Load(stream);
      }
      // change the document
      using (IsolatedStorageFileStream stream = isf.OpenFile("inventories.xml", 
             FileMode.Create,    // the most critical mode-flag
             FileAccess.Write))
       {
           doc.Save(stream);
       }
      
