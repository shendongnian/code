    lblError.Text = null;
    using (var email = new System.Net.Mail.MailMessage(
      new MailAddress(mailer), new MailAddress(webmaster)) {
      email.ReplyTo = txtEmail.Text; // this comes off of your contact form
      string strHtmlBody =
        "<html><body style=\"background-color:#cccccc\">" +
        txtSubject.Text +
        "</body></html>";
      email.Subject = "Website Contact";
      email.Body = strHtmlBody;
      email.IsBodyHtml = true;
      var server = new SmtpClient("relay-hosting.secureserver.net");
      try {
        server.Send(email);
      } catch (Exception err) {
        lblError.Text = err.Message;
      }
    }
