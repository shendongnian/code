    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        private IEnumerator iterator;
 
        public DaysOfTheWeek()
        {
            iterator = days.GetEnumerator();
            iterator.MoveNext();
        }
        public IEnumerator GetEnumerator()
        {
            return iterator;
        }
    }
