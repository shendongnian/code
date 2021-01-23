    bool isXmlValid = false;
    
    try
    {
    
        if (string.IsnNullOrEmpty(dialog.FileName) == false)
        {
           var xmlDoc = new XmlDocument();
           xmlDoc.Load(dialog.FileName);
    
           if (xmlDoc.SelectSingleNode("event/text1") != null &&
               xmlDoc.SelectSingleNode("event/text2") != null)
           {
               // Process accordingly
               isXmlValid = true;
           }
       }
    }
    catch (Exception ex)
    {
        Trace.WriteLine(ex.Message);
    }
    
    if (isXmlValid  == false)
          MessageBox.Show(
             string.Format("Invalid XML file or Xml structure for file ({0})", 
                           dialog.FileName));
