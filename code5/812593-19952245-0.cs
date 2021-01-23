            using (MailMessage eMail = new MailMessage())
            {
                eMail.To.Add(sEmailAddressReceiver); //filled before
                eMail.From = new MailAddress(sEmailAddressSender); //filled before
                eMail.Subject = "Title";
                eMail.Priority = MailPriority.Normal;
                eMail.Body = "File is attached.";
                using (Attachment aAttachment = new Attachment(sFilename))
                {
                    eMail.Attachments.Add(aAttachment);
                    using (SmtpClient smtpClient = new SmtpClient("xxx", 25))
                    {
                        smtpClient.Send(eMail);
                    }
                }
            }
