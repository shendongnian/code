    string date = "0.426574074074074";
    double num;
    if (double.TryParse(date, NumberStyles.Float, CultureInfo.InvariantCulture, out num))
    {
        DateTime dt = DateTime.FromOADate(num);
        // 12/30/1899 10:14:16
        // use DateTime.TimeOfday to get the TimeSpan:
        TimeSpan ts = dt.TimeOfDay; // 10:14:16
    }
