    var textLines = File.ReadAllLines();
    
    foreach (var line in textLines)
    {
       var name = line.Substring(51);
       var address = line.Substring(51,150);
       var bdate = line.Substring(201, 15);
       var gender = line.Substring(216,5);
    }
