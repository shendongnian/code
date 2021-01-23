    Calendar umAlQura = new UmAlQuraCalendar();
    DateTime dt = new DateTime(1434, 11, 23, umAlQura);
    
    // As a string, it will format with whatever the calendar for the culture is.
    Debug.WriteLine(dt.ToString("d", CultureInfo.InvariantCulture)); // 09/29/2013
    Debug.WriteLine(dt.ToString("d", new CultureInfo("ar-SA")));     // 23/11/34
    
    // But the individual integer properties are always Gregorian
    Debug.WriteLine(dt.Year);  // 2013
    Debug.WriteLine(dt.Month); // 9
    Debug.WriteLine(dt.Day);   // 29
