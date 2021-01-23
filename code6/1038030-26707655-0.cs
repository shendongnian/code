    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            DateTime newDateTime = MyDateTimeUtil.CreateDateFromTime(2015, 12, 12, time);
        }
    }
