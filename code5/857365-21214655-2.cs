    using Outlook = Microsoft.Office.Interop.Outlook;
    //---
    Outlook.Application outlookApplication = new Outlook.Application();
    Outlook.MailItem mailitem = (Outlook.MailItem)outlookApplication.ActiveInspector().CurrentItem;
    string myhtml = mailitem.HTMLBody;
