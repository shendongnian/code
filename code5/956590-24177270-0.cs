    string input = "111:217";
    		
    // Split the string into pieces on ":"
    string[] parts = input.Split(':');
    		
    // Create a TimeSpan from our pieces
    int hours = Int32.Parse(parts[0]);
    int minutes = Int32.Parse(parts[1]);
    		
    TimeSpan time = new TimeSpan(hours, minutes, 0);
    		
    // Show the time formatted
    string formatted = time.ToString(@"hh\:mm");
    		
    Console.WriteLine(formatted);	
    		
    // Show the total time in minutes
    double totalMinutes = time.TotalMinutes;
    		
    Console.WriteLine(totalMinutes);
