    string s = "6.3-full-day-care";
    int index = s.IndexOf('-'); //This gets index of first '-' character
    string price = s.Substring(0, index);
    string serviceKey = s.Substring(index + 1);
    Console.WriteLine(price);
    Console.WriteLine(serviceKey);
