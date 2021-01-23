    string testDateStr = "2009.7.28 05:23:15";
        string testDateObj = Convert.ToDateTime(testDateStr).Date.ToString("d");
        string[] validFormats = (Convert.ToDateTime(testDateObj)).GetDateTimeFormats();
        foreach(string s in validFormats)
        {
           lblresult.Text += s;
        }
