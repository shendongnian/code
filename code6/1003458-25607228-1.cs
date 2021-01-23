    var path = @"C:\test.txt";	// Where to save to
    
    // Lets assume this is your input
    var lines = new string[] {"one line", "two line", "three line", "party"};
    
    // This will simply write them all to the file
    System.IO.File.WriteAllLines(path, lines);
    
    // This will append them  to the file
    System.IO.File.AppendAllLines(path, lines);
	// And then you can read it back
	var loaded_from_file = System.IO.File.ReadAllLines
