    bool success = false;
                try { 
                    //try to send the message
                    smtpmail.Send(message);
                    success = true;//everything is good
                }
                catch (Exception err)
                {
                    //error with sending the message
                    errorMsg.Text = ("Unable to send mail at this time. Please try again later.");
                    //log the error 
                    errorLog.Log(err); //note errorLog is another method to log the error
                    //other stuff relating to certain parts of the application visibility
                }
                finally
                {
                    if (success)
                    { 
                        //what to do if the email was successfully sent
                    }
                }
