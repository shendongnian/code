    Outlook.MAPIFolder inbox = 
        Globals.ThisAddIn.Application.Session.DefaultStore
        .GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
    foreach (object item in inbox.Items)
    {
        Outlook.MailItem mail = item as Outlook.MailItem;
        if (mail != null)
        {
            // use the mail item
        }
    }
