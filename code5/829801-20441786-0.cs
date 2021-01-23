    string s = "192.168";
    double d = 0;
    if(s.Contains("."))
    {
        d = Convert.ToDouble(s, CultureInfo.GetCultureInfo("tr-TR"));
    }
    Console.WriteLine(d.ToString("n0")); //192.168
