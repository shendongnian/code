    const string Pattern = "h:mm tt";
    void Sort()
    {
        var Times = new string[]
        {
            "8:00 AM",
            "8:15 AM",
            "8:30 AM",
            "3:00 PM",
            "3:15 PM",
            "11:45 PM",
            "12:00 AM"
        };
        var Dates = Times.OrderBy(x => DateTime.ParseExact(x, Pattern, CultureInfo.InvariantCulture));
    }
