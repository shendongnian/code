    SmtpClient client = new SmtpClient
                                        {
                                            Host = "smtp.gmail.com",
                                            Port = 587,
                                            EnableSsl = true,
                                            DeliveryMethod = SmtpDeliveryMethod.Network,
                                            UseDefaultCredentials = false,
                                            Credentials = new NetworkCredential("gmail_login", "gmail_password")
                                        };
    using( var message = new MailMessage("your_emailAddress", "destination_Email")
                                  {
                                      Subject ="subject",
                                      Body = "body"
                                  })
    client.Send(message);
