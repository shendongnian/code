    Outlook.Application app = new Outlook.Application();
    Outlook.NameSpace outlookNs = app.GetNamespace("MAPI");
    Outlook.MAPIFolder emailFolder = outlookNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
    List<MailItem> ReceivedEmail = new List<MailItem>(); 
    foreach (Outlook.MailItem mail in emailFolder.Items)               
            { ReceivedEmail.Add(mail); }
    foreach (MailItem mail in ReceivedEmail)
    {
        //do stuff
    }
