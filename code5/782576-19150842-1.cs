    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
    Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
        
    oMsg.Subject = "something deployment package instructions";
    oMsg.BodyFormat = OlBodyFormat.olFormatHTML;
    oMsg.HTMLBody = //Here comes your body;
    oMsg.Display(false); //In order to display it in modal inspector change the argument to true
