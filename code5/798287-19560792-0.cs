    using System.Net.Mail;
    public static void Email(string Content, string To, string Subject, List<string> Attach = null, string User = "sender@sender.com", string Password = "MyPassword", string Host = "mail.sender.com", ushort Port = 587, bool SSL = false)
    {
        var Task = new System.Threading.Tasks.Task(() =>
        {
            try
            {
                MailMessage Mail = new MailMessage();
                Mail.From = new MailAddress(User);
                Mail.To.Add(To);
                Mail.Subject = Subject;
                Mail.Body = Content;
                if (null != Attach) Attach.ForEach(x => Mail.Attachments.Add(new System.Net.Mail.Attachment(x)));
                SmtpClient Server = new SmtpClient(Host);
                Server.Port = Port;
                Server.Credentials = new System.Net.NetworkCredential(User, Password);
                Server.EnableSsl = SSL;
                Server.Send(Mail);
            }
            catch (Exception e)
            {
                MessageBox.Show("Email send failed.");
            }
        });
        Task.Start();
    }
