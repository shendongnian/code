    var _thisApp = this.Application;
    Outlook.MailItem _email;
    // Get current email
    if(_thisApp.ActiveWindow() is Outlook.Inspector)
    {
        Outlook.Inspector insp = _thisApp.ActiveWindow() as Outlook.Inspector;
        _email = insp.CurrentItem as Outlook.MailItem;
    }
    else if(_thisApp.AcitveWindow() is Outlook.Explorer)
    {
        Outlook.Explorer exp = _thisApp.ActiveExplorer();
        if(exp.Selection.Count > 0)
            _email = exp.Selection[1] as Outlook.MailItem;
    }
    // Loop through the attachments
    foreach(Outlook.Attachment attachment in _email.Attachments)
    {
        // Some other stuff
        string filePath = @"C:\Saved Attachments\" + attachment.FileName;
        attachment.SaveAsFile(filePath);
    }
