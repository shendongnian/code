    public class DaysOfTheWeek : IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    
        foreach(var day in days){
            Console.WriteLine(day);
        }
    }
