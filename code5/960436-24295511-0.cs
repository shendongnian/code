    MailMessage message = new System.Net.Mail.MailMessage();
    message.To.Add("test1@test.com");
    message.Subject = "Project Created";
    message.From = new MailAddress("noreply@test.com");
    message.Body = "You have recieved a project request from " + TxtContactName.Text + " Project Name: " + TxtProjectName.Text + " Priority: " + DDLPriority.SelectedValue.ToString() + " Business Area: " + DDLBusinessArea.SelectedValue.ToString();
    if (FileUpload1.FileName.Length > 0)
    {
      message.Subject .= string.Format(" ({0} bytes)", FileUpload1.FileName.Length);
      if (File.Exists(FileUpload1.PostedFile.FileName))
      {
        message.Subject .= " E";
        message.Attachments.Add(new Attachment(FileUpload1.PostedFile.FileName));
      }
    }
        
