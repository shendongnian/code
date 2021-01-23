    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        private IEnumerator en;
 
        public DaysOfTheWeek()
        {
            en = days.GetEnumerator();
            en.MoveNext();
        }
        public IEnumerator GetEnumerator()
        {
            return en;
        }
    }
