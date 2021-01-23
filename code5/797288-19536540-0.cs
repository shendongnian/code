    public class DaysOfTheWeek: IEnumerable
    {
        private string[] days = {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};
    
        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }
    }
