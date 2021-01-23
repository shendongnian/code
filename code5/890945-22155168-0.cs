    catch (Exception err)
                    {
                        mailBody = "Error: " + Convert.ToString(err.Message) + "<br /> Source: " + Convert.ToString(err.Source);
                        //Can display some message to user in an Literal Control from here.
                    }
                    finally 
                    {
                        if (!string.IsNullOrEmpty(mailBody))
                        {
                            mailObject.To.Add(mailTo);
                            mailObject.CC.Add(mailCc);
                            mailObject.Body = mailBody;
    
                            MailService(mailObject);
                        }
                    }
