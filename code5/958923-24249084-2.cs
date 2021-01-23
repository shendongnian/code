    Outlook.Application app = new Outlook.Application();
    Outlook.NameSpace outlookNs = app.GetNamespace("MAPI");
    Outlook.MAPIFolder emailFolder = outlookNs.GetDefaultFolder  (Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
    foreach(Outlook.MailItemitem _item in emailFolder.Items.OfType<Outlook.MailItem>().Take(500))
    {
        Console.WriteLine(_item.SenderEmailAddress + " " + _item.Subject + "\n" + _item.Body);
    }
