    var o = new List<string>
    {
        "Hist 2368#19:00:00#20:30:00#Large Conference Room",
        "Hist 2368#09:00:00#10:30:00#Large Conference Room",
    };
    
    var lines = new[]
    {  
        "Meeting#19:00:00#20:30:00#Conference", 
    }.Concat(o).ToArray();
