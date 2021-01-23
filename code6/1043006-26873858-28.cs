    DateTime startDate = DateTime.Today;
    string freeBusy = recipient.AddressEntry.GetFreeBusy(datetime, 60, true);
    foreach(char c in freeBusy)
    {
        if(startDate.Hour == 0)
            Console.WriteLine(startDate.ToString("dd/MM/yyyy"));
        Console.WriteLine(
            "{0}: {1}",
            startDate.ToString("hh tt"),
            c == '1' ? "Busy" : "Free");
        startDate = startDate.AddHours(1);
    }
