    ms.Seek(0, SeekOrigin.Begin);
    System.Net.Mime.ContentType ct= new System.Net.Mime.ContentType();
    ct.MediaType = System.Net.Mime.MediaTypeNames.Application.Pdf;
    ct.Name = "x.pdf";
    Attachment attach = new Attachment(ms, contentType);
    mailMsg.Attachments.Add(attach);
