     var mailtest = new System.Net.Mail.MailMessage()
                    {
                        From = new System.Net.Mail.MailAddress("", ""),
                        Subject = toSend.DirecMessageSubject,
                        IsBodyHtml = true
                    };
mailtest.Headers.Add("Precedence", "bulk");
