    class WeeklyActivityRecorder
    {
       public void Add(string name, DayOfWeek day) { ... }
    }
    
    var recorder = new WeeklyActivityRecorder {
        { "DeepSeaDiving", DayOfWeek.Monday },
        { "Lawn Mowing", DayOfWeek.Tuesday} };
