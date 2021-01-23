    foreach (char c in freeBusy) //iteration process
    {
        if (startDate.Hour == 0 ) //start at 12 AM
            Contacts.Items.Add(startDate.ToString("dd/MM/yyyy"));
        if(8 <= startDate.Hour && startDate.Hour <= 18) // 8AM to 6PM inclusive
        {
            listBox1.Items.Add(
                String.Format(
                "{0}: {1}", 
                startDate.ToString("hh tt"),
                c == '1' ? "Busy" : "Free"));
        }
        
        startDate = startDate.AddHours(1);
        if(startDate.Date > DateTime.Today)
            break; // stop once we get to tomorrow.
    }
