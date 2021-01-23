    String tmpDate = "Friday, 27th September 2013";
    string[] split = tmpDate.Split();
    string[] ordinals = new string[] { "th", "nd", "st" };
    foreach (string ord in ordinals)
       split[1] = split[1].Replace(ord, "");
    tmpDate = String.Join(" ", split);
    DateTime dt;
    if(DateTime.TryParseExact(tmpDate, "dddd, dd MMMM yyyy",null, DateTimeStyles.None, out dt))
    {
       Console.WriteLine("Parsed");
    }
    else
    {
       Console.WriteLine("Could not parse");
    }
   
