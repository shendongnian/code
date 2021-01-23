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
    
    msg.Body = <h1>Hello World!!</h1>";
    msg.Subject = "This is a sample message";
    
    for (int i = 0; i < dataGridView.Rows.Count; i++)
    {
        if (dataGridView.Rows[i].Cells["DRAFT_PATH"].Value != null && 
    		System.IO.File.Exists(dataGridView.Rows[i].Cells["DRAFT_PATH"].Value.ToString()))
    	{
    		msg.Attachments.Add(new Attachment(dataGridView.Rows[i].Cells["DRAFT_PATH"].Value.ToString()));
    	}
    }
    
    smtp.Send(msg);
