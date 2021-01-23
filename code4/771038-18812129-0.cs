        var ci = new CultureInfo("en-US");
        DateTime entry = DateTime.ParseExact("7:50 AM", "h:mm tt", ci);
        DateTime leave = DateTime.ParseExact("6:15 PM", "h:mm tt", ci);
        TimeSpan t = leave - entry - TimeSpan.FromMinutes(30);
        
        MessageBox.Show(t.TotalHours.ToString());
