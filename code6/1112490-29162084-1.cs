    var maxTicks = DateTime.MaxValue.Ticks; 
    Console.WriteLine("Max ticks:");
    Console.WriteLine(maxTicks); // 3155378975999999999
    var maxedDate = new DateTime(DateTime.MaxValue.Year,
                                DateTime.MaxValue.Month, 
                                DateTime.MaxValue.Day, 
                                DateTime.MaxValue.Hour, 
                                DateTime.MaxValue.Minute, 
                                DateTime.MaxValue.Second, 
                                DateTime.MaxValue.Millisecond);
    var ticksFromDate = maxedDate.Ticks; 
    Console.WriteLine("Max ticks from date:");
    Console.WriteLine(ticksFromDate); // 3155378975999990000
    var withExtraTicks = maxedDate.AddTicks(9999);
    Console.WriteLine("Max date with ticks added:");
    Console.WriteLine(withExtraTicks.Ticks); // 3155378975999999999
    try{ 
        var tooLong = withExtraTicks.AddTicks(1); 
        Console.WriteLine("Note: This line will only be shown if run on Diskworld.");
    }
    catch(Exception ex){
        Console.WriteLine("Failed! Message:");
        // Will show the message:
        // "The added or subtracted value results in an un-representable DateTime."
        Console.WriteLine(ex.Message); 
    }
