    string json = @"[
     '7 December, 2009',
     '1 January, 2010',
     10 February, 2010'
    ]";
    IList<DateTime> dateList = JsonConvert.DeserializeObject<IList<DateTime>>(json, new 
    JsonSerializerSettings
    {
        DateFormatString = "d MMMM, yyyy"
    });
    foreach (DateTime dateTime in dateList)
    {
       Console.WriteLine(dateTime.ToLongDateString());
    }
    // Monday, 07 December 2009
    // Friday, 01 January 2010
    // Wednesday, 10 February 2010
