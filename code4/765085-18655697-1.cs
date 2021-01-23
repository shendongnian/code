    string input = "9:00 PM";
    if (input.IndexOf("PM") > 0)
    {
         DateTime dt = DateTime.Today.Date;
         int hour = Int32.Parse(input[0].ToString()) + 12;
         TimeSpan ts = new TimeSpan(0, hour, 0, 0, 0);
         Console.WriteLine(dt.Add(ts));
    }
