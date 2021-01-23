    public void SendEmail(ListDictionary email)
            {
                try
                {
                    var msg = new MailMessage {From = new MailAddress(_emailUsername, _emailFrom), BodyEncoding = Encoding.UTF8, Subject = Convert.ToString(email["SUBJECT"]), Priority = MailPriority.Normal};
                    //
                    var emailTo = (List<string>) email["TO"];
                    var emailCc = (List<string>) email["CC"];
                    var emailBcc = (List<string>) email["BCC"];
                    foreach (var to in emailTo.Where(to => to.Length > 1))
                        msg.To.Add(to);
                    foreach (var cc in emailCc.Where(cc => cc.Length > 1))
                        msg.CC.Add(cc);
                    foreach (var bcc in emailBcc.Where(bcc => bcc.Length > 1))
                        msg.Bcc.Add(bcc);
                    //
                    msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(Convert.ToString(email["BODY_TEXT"]), Encoding.UTF8, "text/plain"));
                    msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(Convert.ToString(email["BODY_HTML"]), Encoding.UTF8, "text/html"));
                    //
                    new SmtpClient
                    {
                        Credentials = new NetworkCredential(_emailUsername, _emailPassword),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = true,
                        Host = "smtp.gmail.com"
                    }.Send(msg);
                }
                catch (Exception e)
                {
                    L.Get().Fatal("Failed", e);
                }
            }
