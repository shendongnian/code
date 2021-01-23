    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Application.ItemSend += Application_ItemSend;
        Application.NewMailEx += Application_NewMailEx;
    }
    void Application_NewMailEx(string EntryIDCollection)
    {
        string[] arr = EntryIDCollection.Split(',');
        foreach(string entry in arr)
        {
            var item = Application.Session.GetItemFromID(entry.Trim(), Type.Missing);
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
