    StringBuilder sb = new StringBuilder();
    foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
    {
        try
        {
            Thread.CurrentThread.CurrentCulture = culture;
            DateTime testDateTime = new DateTime(2014, 12, 13, 23, 24, 25);
            String testString = testDateTime.ToString(CultureInfo.InvariantCulture);
            DateTime actualDateTime = DateTime.Parse(testString);
            Console.WriteLine(actualDateTime.Day.ToString());
        }
        catch (Exception ex)
        {
           sb.AppendLine(culture.ToString());
        }
    }
    Console.WriteLine(sb.ToString());
