    Microsoft.Office.Interop.Outlook.Application outlookObject = new Microsoft.Office.Interop.Outlook.Application();
    MAPIFolder contactFolder = outlookObject.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
    Items contacts = contactFolder.Items;
    MAPIFolder calendar = outlookObject.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
    Items appointments = calendar.Items;
    appointments.IncludeRecurrences = true;
