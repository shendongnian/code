        using(var ms = new System.IO.MemoryStream())
        {
          using(var writer = new System.IO.StreamWriter(ms))
          {
             writer.Write("Hello its my sample file");
             writer.Flush();
             System.Net.Mime.ContentType ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Text.Plain);
             System.Net.Mail.Attachment attach = new System.Net.Mail.Attachment(ms, ct);
             attach.ContentDisposition.FileName = "myFile.txt";
             mm.Attachments.Add(attach);
             try
             {
                 client.Send(mm);
             }
             catch(SmtpException e)
             {
                Console.WriteLine(e.ToString());
             }
           }
        }
