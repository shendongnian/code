     public static Outlook.Account GetAccountForEmailAddress(Outlook.Application application, string smtpAddress) 
     { 
 
         // Loop over the Accounts collection of the current Outlook session. 
         Outlook.Accounts accounts = application.Session.Accounts; 
         foreach (Outlook.Account account in accounts) 
         { 
             // When the e-mail address matches, return the account. 
             if (account.SmtpAddress == smtpAddress) 
             { 
                return account; 
             } 
         } 
         throw new System.Exception(string.Format("No Account with SmtpAddress: {0} exists!", smtpAddress)); 
     } 
    public static string Send_Email_Outlook(string _recipient, string _message, string _subject, string _cc, string _bcc, string accountname)
    {
        try
        {
            Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
            // Get the NameSpace and Logon information.
            Microsoft.Office.Interop.Outlook.NameSpace oNS = oApp.GetNamespace("mapi");
            // Log on by using a dialog box to choose the profile.
            oNS.Logon(Missing.Value, Missing.Value, true, true);
            // Create a new mail item.
            Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            // Set the subject.
            oMsg.Subject = _subject;
            // Set HTMLBody.
            oMsg.HTMLBody = _message;
            oMsg.To = _recipient;
            oMsg.CC = _cc;
            oMsg.BCC = _bcc;
            #region Send via another account
             // Retrieve the account that has the specific SMTP address. 
            Outlook.Account account = GetAccountForEmailAddress(oApp , "support@mydomain.com"); 
            // Use this account to send the e-mail. 
            oMsg.SendUsingAccount = account; 
            // Send.
            (oMsg as Microsoft.Office.Interop.Outlook._MailItem).Send();
            // Log off.
            oNS.Logoff();
            // Clean up.
            //oRecip = null;
            //oRecips = null;
            oMsg = null;
            oNS = null;
            oApp = null;
        }
     // Return Error Message
        catch (Exception e)
        {
            return e.Message;
        }
        // Default return value.
        return "";
    }
