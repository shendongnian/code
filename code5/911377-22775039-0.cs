    // index starts from 1.
    for(int i = 1; i <= oItems.Count; i++)
    {
        Microsoft.Office.Interop.Outlook.MailItem oMsg = ( Microsoft.Office.Interop.Outlook.MailItem)oItems[i];
        textEmail.Text += "\r\nSubject:" + oMsg.Subject.ToString();
    }
