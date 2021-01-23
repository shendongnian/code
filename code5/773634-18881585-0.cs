    String original = "2011-05-17 00:00:00 Etc/GMT";
    DateTime result = DateTime.ParseExact(
        original,
        "yyyy-MM-dd HH:mm:ss 'Etc/GMT'",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.AssumeUniversal);
    Console.WriteLine(result.ToString()); // given my timezone: 5/16/2011 8:00:00 PM
    Console.WriteLine(result.ToUniversalTime().ToString()); // 5/17/2011 12:00:00 AM
