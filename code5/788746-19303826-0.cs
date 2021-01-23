    string[] times = { "12:00 AM", "12:00 PM", "12:05 AM" };
             const string timePattern = "h:mm tt";
    
             var dateTime = new DateTime(2010,1,1,0,0,0,0);
             foreach (var time in times)
             {
                var parsedDate = DateTime.ParseExact(time, timePattern, null, DateTimeStyles.None);
                dateTime = dateTime.AddHours(parsedDate.Hour);
                dateTime = dateTime.AddMinutes(parsedDate.Minute);
             }
             Console.WriteLine(a.ToShortTimeString());
             Console.ReadKey();
