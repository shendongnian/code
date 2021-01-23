    UmAlQuraCalendar umAlQura = new UmAlQuraCalendar();
    DateTime dt = new DateTime(1434, 11, 23, umAlQura);
    
    Debug.WriteLine(dt.ToShortDateString());  // 9/29/2013   (Gregorian)
    
    // The individual integer properties are also Gregorian
    Debug.WriteLine(dt.Year);  // 2013
    Debug.WriteLine(dt.Month); // 9
    Debug.WriteLine(dt.Day);   // 29
