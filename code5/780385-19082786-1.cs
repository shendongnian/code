    DateTime dt = new DateTime(2013, 9, 29);  // Gregorian
    Calendar umAlQura = new UmAlQuraCalendar();
    Debug.WriteLine(umAlQura.GetYear(dt));       // 1434
    Debug.WriteLine(umAlQura.GetMonth(dt));      // 11
    Debug.WriteLine(umAlQura.GetDayOfMonth(dt)); // 23
