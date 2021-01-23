            string mailFromId = System.Configuration.ConfigurationManager.AppSettings["Sender"];
            SendGridMessage sndmsg = new SendGridMessage();
            sndmsg.From = new MailAddress(mailFromId);
            sndmsg.To = new MailAddress[] { new MailAddress(offMail) };
            if (!string.IsNullOrEmpty(ccMail))
            {
                sndmsg.Cc = new MailAddress[] { new MailAddress(ccMail) };
            }
            if(!string.IsNullOrEmpty(bccMail))
            {
                sndmsg.Bcc = new MailAddress[] { new MailAddress(bccMail) };
            }
            sndmsg.Subject = subject;         
            sndmsg.Html = "<div>" + mailFormatDetails + "</div>";
            bool result= SendEmail(sndmsg);
            return result;
        }
