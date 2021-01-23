    protected void Application_Error(Object sender, EventArgs e)
    {
    	Exception ex = Server.GetLastError();
    	EmailTheException( ex );
    }
    
    private void EmailTheException( Exception ex )
    {
    	MailMessage mail = new MailMessage();
    	mail.To = "GroupEmail@SomeCompany.com";
    	mail.From = "SomeApplication@SomeCompany.com";
    	mail.Subject = "An Application Exception has Occurred.";
    	mail.Body = ex.ToString();
    	
        var smtpHost = ConfigurationManager.AppSettings["smtphost"];
        var port = Convert.ToUInt32(ConfigurationManager.AppSettings["port"]);
        using (SmtpClient client = new SmtpClient(smtpHost))
        {
            if (string.IsNullOrEmpty(smtpHost)) return;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            try
            {
                client.Send(mail);
            }
            catch (SmtpException smtpEx)
            {
               //write logging code here and capture smtpEx.Message
            }
        }
    }
