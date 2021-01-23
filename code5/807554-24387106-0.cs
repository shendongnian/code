    using (FileSteam f = new FileStream(xmlResponsePath))
    {
         responseDoc = XDocument.Load(sr);
         var elementResponse = responseDoc.Root;
         elementResponse.SetAttributeValue("BatchID", batchId);
         responseDoc.Save(sw);                    
    }
