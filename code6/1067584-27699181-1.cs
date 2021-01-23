    public void SendEmail(string _from, string _fromDisplayName, string _to, string _toDisplayName, string _subject, string _body, string _password)
        {
            try
            {
                SmtpClient _smtp = new SmtpClient();
                MailMessage _message = new MailMessage();
                _message.From = new MailAddress(_from, _fromDisplayName); // Your email address and your full name
                _message.To.Add(new MailAddress(_to, _toDisplayName)); // The recipient email address and the recipient full name // Cannot be edited
                _message.Subject = _subject; // The subject of the email
                _message.Body = _body; // The body of the email
                _smtp.Port = 587; // Google mail port
                _smtp.Host = "smtp.gmail.com"; // Google mail address
                _smtp.EnableSsl = true;
                _smtp.UseDefaultCredentials = false;
                _smtp.Credentials = new NetworkCredential(_from, _password); // Login the gmail using your email address and password
                _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                _smtp.Send(_message);
                ShowMessageBox("Your message has been successfully sent.", "Success", 2);
            }
            catch (Exception ex)
            {
                ShowMessageBox("Message : " + ex.Message + "\n\nEither your e-mail or password incorrect. (Are you using Gmail account?)", "Error", 1);
            }
        }
