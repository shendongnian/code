    var csv = 
    @",,SomeColumn,,,
    ab,cd,ef,,,";  // Ef is the "SomeColumn"
    
    var data = new myDynamicClass(csv); // This holds multiple myDynamicClassDataLine items
        	
    Console.WriteLine (data.OfType<dynamic>().First()["SomeColumn"]); // "ef" is the output.
