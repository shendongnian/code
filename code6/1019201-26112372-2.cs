    SmtpClient smtp = new SmtpClient();
    MailMessage msg = new MailMessage();
    msg.From = new MailAddress("stacy@gmail.com", "Stacy Kebler");
    smtp.Host = "smtp.gmail.com";
    smtp.Port = 465;  //set the default smtp port of email provider. you can avoid it if you don't know
    smtp.Credentials = new System.Net.NetworkCredential("stacy@gmail.com", "stacy123");
    smtp.EnableSsl = true; //Set this to true if the email provider is using SSL encryption 
    smtp.Timeout = 10000; //Set the timeout to 10 second
    
    msg.To.Add(new MailAddress("abc@gmail.com","Mr. ABC"));
    msg.IsBodyHtml = true; //if the content of body is in HTML format then set it to true.
    
    
    msg.Subject = "This is a sample message";
    
    StringBuilder sbBody = new StringBuilder();
    sbBody.Append("This is the Sample Email <br><br>");
    for (int i = 0; i < dataGridView.Rows.Count; i++)
    {
        if (dataGridView.Rows[i].Cells["DRAFT_PATH"].Value != null && 
    		System.IO.File.Exists(dataGridView.Rows[i].Cells["DRAFT_PATH"].Value.ToString()))
    	{
    		string path = dataGridView.Rows[i].Cells["DRAFT_PATH"].Value.ToString();
    		sbBody.AppendFormat("File {0}:{1}<br>", i + 1, Path.GetFileNameWithoutExtension(path))
    		msg.Attachments.Add(new Attachment(path));
    	}
    }
    msg.Body = sbBody.ToString();
    
    smtp.Send(msg);
