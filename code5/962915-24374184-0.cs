    class Program
    {
        static void Main(string[] args)
        {
            object stringDate = "";
            object dateTime = new DateTime();
            DateUtils.DateStringGetter(ref stringDate);
            DateUtils.DateStringGetter(ref dateTime);
        }
    }
    public static class DateUtils
    {
        private static DateTime DateStringConverter(string mmddyyyy, char delim = '/')
        {
            string[] date = mmddyyyy.Split(delim);
            DateTime fileTime = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[0]),
                Convert.ToInt32(date[1]));
            return fileTime;
        }
        public static void DateStringGetter(ref object date)
        {
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string sDay = DateTime.Now.Day.ToString().PadLeft(2, '0');
            if (date is String)
            {
                date = sMonth + '/' + sDay + '/' + sYear;
            }
            if (date is DateTime)
            {
                date = DateStringConverter(sMonth + '/' + sDay + '/' + sYear);
            }
        }
    }
