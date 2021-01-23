    Console.WriteLine("Please enter the Month you were born: ");
    string s = Console.ReadLine();
    int month;
    if(Int32.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out month))
    {
       // Your string input is valid to convert integer.
       month = int.Parse(s);
    }
    else
    {
       // Your string input is invalid to convert integer.
    }
