    String a = "08:0"; // text as string 
    
    DateTime time= new DateTime(); // Passed result if succeed 
    
     if (DateTime.TryParseExact(a, "hh:mm", new CultureInfo("en-US"), DateTimeStyles.None, out time)) {
        Console.WriteLine("pass");
     }
     else {
        Console.WriteLine("fail");
     }
