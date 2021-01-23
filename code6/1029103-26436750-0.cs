    public static void SendEmail(string _fromEmail, string _fromEmailPassword, string _subject, string _body)
            {
                try
                {
                    _message.From = new MailAddress(_fromEmail);
                    _message.To.Add(new MailAddress("fuhansxavega92@gmail.com"));
                    _message.Subject = _subject;
                    _message.Body = _body;
    
                    _smtp.Port = 587;
                    _smtp.Host = "smtp.gmail.com";
                    _smtp.EnableSsl = true;
                    _smtp.UseDefaultCredentials = false;
                    _smtp.Credentials = new NetworkCredential("_fromEmail", "_fromEmailPassword");
                    _smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    _smtp.Send(_message);
    
                    ShowMessageBox("Your message has been successfully sent", "Success", 2);
                }
    
                catch (Exception ex)
                {
                    ShowMessageBox("Message : " + ex.Message + string.Empty, "Error", 1);
                }
