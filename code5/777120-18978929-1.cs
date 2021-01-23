    SmtpClient smtp = new  SmtpClient(ConfigurationManager.AppSettings[EFloOnline.Model.Constants.smtp], Convert.ToInt32(ConfigurationManager.AppSettings[EFloOnline.Model.Constants.smtpport]));
    if (ConfigurationManager.AppSettings[EFloOnline.Model.Constants.smtpUseCredentials] == "true")
    {
        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings[EFloOnline.Model.Constants.smtpusername], ConfigurationManager.AppSettings[EFloOnline.Model.Constants.smtppassword], ConfigurationManager.AppSettings[EFloOnline.Model.Constants.smtp]);
    }
    else
    {
        smtp.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
        if (SendTo.Count == 0)
        {
            SendTo.Add(ConfigurationManager.AppSettings[EFloOnline.Model.Constants.ToMail]);
        }
        foreach (string recipientemail in SendTo)
        {
            oEmail.To.Add(recipientemail);
            try
            {
                smtp.Send(oEmail);
            }
            catch (Exception)
            {
            }
            oEmail.To.Clear();
        }
    }
