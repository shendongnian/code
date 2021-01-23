    // Note the addition of hours, minutes and seconds:
    var today = new DateTime(2014, 3, 11, 14, 35, 33); 
    if(today == DateTime.Today){
        Console.WriteLine("This never happened...");    
    }
    if(today.Date == DateTime.Today){
        Console.WriteLine("...But today is still the day!");    
    }
