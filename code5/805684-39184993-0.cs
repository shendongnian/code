    var now = DateTime.Now;
    var later = now.AddHours(1);
    
    var e = new Event
    {
        DtStart = new CalDateTime(now),
        DtEnd = new CalDateTime(later),
    };
    e.AddProperty("X-MICROSOFT-CDO-BUSYSTATUS", "OOF"); // I think "OOF" is right per the MS documentation
    
    var calendar = new Calendar();
    calendar.Events.Add(e);
    
    var serializer = new CalendarSerializer(new SerializationContext());
    var icalString = serializer.SerializeToString(calendar);
    Console.WriteLine(icalString);
