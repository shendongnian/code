    public static void Main(string[] args) {
        //Your code goes here
        TimeSpan span = (Next(DateTime.Now, DayOfWeek.Sunday).Date + new TimeSpan(23, 59, 00)).Subtract(DateTime.Now);          
        Console.WriteLine(span.TotalSeconds);
    }
    public static DateTime Next(DateTime from, DayOfWeek dayOfWeek) {
       int start = (int) from.DayOfWeek;
       int target = (int) dayOfWeek;
       if (target <= start) target += 7;
         return from.AddDays(target - start);
    }
