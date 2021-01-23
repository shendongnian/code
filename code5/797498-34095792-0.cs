    // returns a date 'MM/dd/yyyy' string from a datetime string '2014-06-19 00:00:00.000'
    public static string stripTime(string s) {
        string date = "";
        DateTime dt = DateTime.Parse(s);
        date = dt.Date.ToString("MM/dd/yyyy");
        return date;
    }
    // returns a date 'MM/dd/yyyy'string  from a datetime datetime 
    public static string stripTime(DateTime d) {
        string date = "";
        date = d.Date.ToString("MM/dd/yyyy");
        return date;
    }
