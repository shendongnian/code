    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        this.Application.NewMail += new Microsoft.Office.Interop.Outlook.
            ApplicationEvents_11_NewMailEventHandler
            (ThisAddIn_NewMail);
    }
    private void ThisAddIn_NewMail()
    {
        Outlook.MAPIFolder inBox = (Outlook.MAPIFolder)this.Application.
            ActiveExplorer().Session.GetDefaultFolder
            (Outlook.OlDefaultFolders.olFolderInbox);
        Outlook.Items items = (Outlook.Items)inBox.Items;
        Outlook.MailItem moveMail = null;
        items.Restrict("[UnRead] = true");
        Outlook.MAPIFolder destFolder = inBox.Folders["Test"];
        foreach (object eMail in items)
        {
            try
            {
                moveMail = eMail as Outlook.MailItem;
                if (moveMail != null)
                {
                    string titleSubject = (string)moveMail.Subject;
                    if (titleSubject.IndexOf("Test") > 0)
                    {
                        moveMail.Move(destFolder);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
