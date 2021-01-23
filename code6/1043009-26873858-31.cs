    DateTime startDate = DateTime.Today; //gets todays date
    string freeBusy = recipient.AddressEntry.GetFreeBusy(datetime, 60, true);
    Contacts.Items.Add(startDate.ToString("dd/MM/yyyy")); 
    startDate = startDate.AddHours(8); //Skip to 8 am
    foreach (char c in freeBusy.Skip(8).Take(11)) // skip to 8AM and only go to 6PM
    {
        listBox1.Items.Add(
            String.Format(
                "{0}: {1}", 
                startDate.ToString("hh tt"),
                c == '0' ? "Free" : "Busy"));
               
        startDate = startDate.AddHours(1);
    }
