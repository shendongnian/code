    var outlookApp = new Microsoft.Office.Interop.Outlook.Application();
    MailItem mailItem = outlookApp.CreateItem(OlItemType.olMailItem);
    mailItem.Subject = "subject";
    var inspector = mailItem.GetInspector; // Force the "HTMLBody" property to be populated with any email signature, so that we can append it to our content.
    mailItem.HTMLBody = "My message" + mailItem.HTMLBody;
    mailItem.Attachments.Add("attachment.dat", OlAttachmentType.olByValue);
    mailItem.Display(false); // Display the email
    inspector.Activate(); // Bring the editor to the foreground.
