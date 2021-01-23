    string input = "125"; // your input, could be replaced with Console.ReadLine()
    
    foreach (char c in input) {
        int decValue = (int)c; // Convert ASCII character to an integer
        string hexValue = decValue.ToString("X"); // Convert the integer to hex value
    
        Console.WriteLine(hexValue);
    }
