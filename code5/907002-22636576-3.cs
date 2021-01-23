    XDocument doc; // declare outside of the using scope
    using (IsolatedStorageFileStream stream = isf.OpenFile("inventories.xml", 
               FileMode.Open, FileAccess.Read))
    {
        doc = XDocument.Load(stream);
    }
    
    // change the document here
    
    using (IsolatedStorageFileStream stream = isf.OpenFile("inventories.xml", 
           FileMode.Create,    // the most critical mode-flag
           FileAccess.Write))
    {
       doc.Save(stream);
    }
