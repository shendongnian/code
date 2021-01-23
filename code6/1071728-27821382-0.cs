    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        MAPIFolder inbox =
            this.Application.ActiveExplorer().Session.GetDefaultFolder
            (Outlook.OlDefaultFolders.olFolderInbox);
        Items unreadItems = inbox.Items.Restrict("[Unread]=true");
        foreach (var unreadItem in unreadItems)
        {
            // Process item
            Marshal.ReleaseComObject(unreadItem);
        }
    }
