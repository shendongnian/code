    writer.Flush();
    ms.Position = 0; // <===== here
    System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(
        System.Net.Mime.MediaTypeNames.Text.Plain);
    System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
