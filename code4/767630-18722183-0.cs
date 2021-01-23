    private void sendEmailNotification(string aretheyManager, 
                                      string listedanalystEmail, 
                                      string listedmanagerEmail)
    {
        //Create an email to send notifying of contract termination
        MailMessage message = new MailMessage();
        //Check to see if the listed analyst is a manager
        //If they are, send the email to them
        //If they are not, send they email to their manager.
        if (aretheyManager == "True")
        {
            message.To.Add(listedanalystEmail);
        }
        else
        {
            message.To.Add(listedmanagerEmail);
        }
        message.Subject = "This contract requires your attention!";
        message.From = new MailAddress("no response email address goes here");
        message.Body = "There is an application contract that is in need of renewal.";
        message.Priority = MailPriority.Normal;
        SmtpClient client = new SmtpClient("client info goes here");
        client.Send(message);
    }
