    var mimeContent2 = itemAttachment.Item.MimeContent;
    byte[] ContentBytes = mimeContent2.Content;
    
    //convert array of bytes into file
    FileStream objfileStream = new FileStream("C:\\email2case\\temp\\testing" + System.DateTime.Now.ToString("HHmmss") + ".eml", FileMode.Create);
    objfileStream.Write(ContentBytes, 0, ContentBytes.Length);
    objfileStream.Close();
