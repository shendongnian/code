    public static class MyDateTimeExtension
    {
        public static string ToMyCulture(this DateTime dt, CultureInfo info)
        {
             ...
        }
    }
    DateTime timeTest = DateTime.Now;
    var myTimeString = timeTest.ToMyCulture(new CultureInfo("en-US"));
