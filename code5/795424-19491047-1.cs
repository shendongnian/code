    class WeeklyActivityRecorder : IEnumerable
    {
       public void Add(string name, DayOfWeek day) { ... }
       IEnumerator IEnumerable.GetEnumerator() { return Activities.GetEnumerator(); }
    }
    
    var recorder = new WeeklyActivityRecorder {
        { "DeepSeaDiving", DayOfWeek.Monday },
        { "Lawn Mowing", DayOfWeek.Tuesday} };
