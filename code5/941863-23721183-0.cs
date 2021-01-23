    DateTime ourDateTime;
    bool success = DateTime.TryParseExact(Date, "yyyyMMdd-HHmmss", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out ourDateTime);
    if(success) {
        StartTime.Text = ourDateTime.ToString("g");
    }
