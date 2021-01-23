    public class DaysOfTheWeek: IEnumerable
    {
        private string[] days = {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};
    
        public IEnumerator GetEnumerator()
        {
            var enumerator = days.GetEnumerator();
            while(enumerator.MoveNext())
            { 
                yield return enumerator.Current;
            }
        }
    }
