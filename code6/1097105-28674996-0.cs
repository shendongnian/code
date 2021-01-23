    var client = new TcpClient("time.nist.gov", 13);
    using (var streamReader = new StreamReader(client.GetStream()))
    {
        var response = streamReader.ReadToEnd();
        var utcDateTimeString = response.Substring(7, 17);
        var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
    }
