    public struct DateWrap
    {
        DateTime date;
        public static implicit operator DateWrap(DateTime dt)
        {
            return new DateWrap() { date=dt };
        }
        public static implicit operator DateTime(DateWrap dw)
        {
            return dw.date;
        }
        public static explicit operator int(DateWrap dw)
        {
            return int.Parse(dw.date.ToShortDateString().Replace("/", "").Replace("-", ""));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt=DateTime.Now;
            int x=(int)(DateWrap)dt;
            // x = 5112014
        }
    }
