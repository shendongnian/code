    using Outlook = Microsoft.Office.Interop.Outlook;
    
    try
    {
        string[] fileEntries = System.IO.Directory.GetFiles(txtPdfFiles.Text, "*.pdf");
        Outlook.Application oApp = new Outlook.Application();   
        Outlook.MailItem oMsg = Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
        Outlook.Inspector oInspector = oMsg.GetInspector;
       
        // ...
    }
