    string input = "9:00 PM";
    if (input.IndexOf("PM") > 0)
    {
         DateTime dt = DateTime.Today;
         TimeSpan ts = new TimeSpan(12 + (int)input[0], 0, 0);
         dt = dt.Add(ts);
         Console.WriteLine(dt);
    }
