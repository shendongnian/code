    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Application.ItemSend += Application_ItemSend;
        Application.NewMailEx += Application_NewMailEx;
    }
    void Application_NewMailEx(string EntryIDCollection)
    {
    #if !OLD_METHOD
        Outlook.NameSpace nameSpace = Application.GetNamespace("MAPI");
    #endif
        string[] arr = EntryIDCollection.Split(',');
        foreach(string entry in arr)
        {
    #if OLD_METHOD
            var item = Application.Session.GetItemFromID(entry.Trim(), Type.Missing);
    #else
            var item = nameSpace.GetItemFromID(entry.Trim(), Type.Missing);
    #endif
            // COMException is thrown there quite often when entry is a meeting.
            if (item is Outlook.MailItem)
            {
                // ... Do something with the email
            }
            else if (item is Outlook.AppointmentItem)
            {
                // ... Do something with the appointment
            }
            else if (item is Outlook.MeetingItem)
            {
                // ... Do something with the meeting
            }
        }
    }
