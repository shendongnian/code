    string value =  "Page1: This is my new Page1     --------     Page2: This is my new Page 2     --------     Page3: This is my new Page3     --------     ";
    string[] delimiters = new string[] { "     --------     " };
    string[] parts = value.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    foreach (var item in parts)
    {
        Console.WriteLine(item);
    }
