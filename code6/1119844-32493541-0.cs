    ByteArrayContent fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                     {
                          Name = "attachment",
                          FileName = "MyAttachment.pdf"
                     };
            
    content.Add(fileContent);
