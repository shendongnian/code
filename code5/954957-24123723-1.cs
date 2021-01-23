    bool success = false;
                try { 
                    smtpmail.Send(message);
                    success = true;
                }
                catch (Exception err)
                {
                    errorMsg.Text = ("Unable to send mail at this time. Please try again later.");
                    //logging the error 
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
