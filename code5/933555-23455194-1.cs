    using Outlook = Microsoft.Office.Interop.Outlook;
    
    try
    {
        string[] fileEntries = System.IO.Directory.GetFiles(txtPdfFiles.Text, "*.pdf");
        Outlook.Application oApp = new Outlook.Application();
    
        // Logon if you create your own Outlook instance  
        var session = oApp.GetNamespace("MAPI");
        session.Logon();
    
        Outlook.MailItem oMsg = Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
        // ...
    }
