    void Main()
    {
        var daysOfWeek = DaysBetween(
            new DateTime(2015, 1, 14), 
            new DateTime(2015, 1, 17));
    
        Console.WriteLine(
            String.Join(", ", daysOfWeek.Select(d => d.ToString().Substring(0, 3))));
        // prints: Wed, Thu, Fri, Sat
    }
    
    IEnumerable<DayOfWeek> DaysBetween(DateTime start, DateTime end)
    {
        for (var dateTime = start; dateTime <= end; dateTime = dateTime.AddDays(1))
        {
            yield return dateTime.DayOfWeek;
        }
    }
