    public void mail()
        {
            MailMessage sendmsg = new MailMessage("frommail", "tomail", "subject", "body"); 
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = Convert.ToInt16("587");
            client.Credentials = new System.Net.NetworkCredential("frommail", "password");
            Attachment sMailAttachment;
            sMailAttachment = new Attachment("your file");
            sendmsg.Attachments.Add(sMailAttachment);
            client.EnableSsl = true;
            client.Send(sendmsg);
        }
