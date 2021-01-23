    /* This is a benchmarking template I use in LINQPad when I want to do a
     * quick performance test. Just give it a couple of actions to test and
     * it will give you a pretty good idea of how long they take compared
     * to one another. It's not perfect: You can expect a 3% error margin
     * under ideal circumstances. But if you're not going to improve
     * performance by more than 3%, you probably don't care anyway.*/
    void Main()
    {
        // Enter setup code here
        var actions = new[]
        {
            new TimedAction("control", () =>
            {
                int i = 0;
            }),
            new TimedAction("<", () =>
            {
               for (int i = 0; i < 1000001; i++)
                {}
            }),
            new TimedAction("<=", () =>
            {
               for (int i = 0; i <= 1000000; i++)
                {}
            }),
            new TimedAction(">", () =>
            {
               for (int i = 1000001; i > 0; i--)
                {}
            }),
            new TimedAction(">=", () =>
            {
               for (int i = 1000000; i >= 0; i--)
                {}
            })
        };
        const int TimesToRun = 10000; // Tweak this as necessary
        TimeActions(TimesToRun, actions);
    }
    
    
    #region timer helper methods
    // Define other methods and classes here
    public void TimeActions(int iterations, params TimedAction[] actions)
    {
        Stopwatch s = new Stopwatch();
        int length = actions.Length;
        var results = new ActionResult[actions.Length];
        // Perform the actions in their initial order.
        for(int i = 0; i < length; i++)
        {
            var action = actions[i];
            var result = results[i] = new ActionResult{Message = action.Message};
            // Do a dry run to get things ramped up/cached
            result.DryRun1 = s.Time(action.Action, 10);
            result.FullRun1 = s.Time(action.Action, iterations);
        }
        // Perform the actions in reverse order.
        for(int i = length - 1; i >= 0; i--)
        {
            var action = actions[i];
            var result = results[i];
            // Do a dry run to get things ramped up/cached
            result.DryRun2 = s.Time(action.Action, 10);
            result.FullRun2 = s.Time(action.Action, iterations);
        }
        results.Dump();
    }
    
    public class ActionResult
    {
        public string Message {get;set;}
        public double DryRun1 {get;set;}
        public double DryRun2 {get;set;}
        public double FullRun1 {get;set;}
        public double FullRun2 {get;set;}
    }
    
    public class TimedAction
    {
        public TimedAction(string message, Action action)
        {
            Message = message;
            Action = action;
        }
        public string Message {get;private set;}
        public Action Action {get;private set;}
    }
    
    public static class StopwatchExtensions
    {
        public static double Time(this Stopwatch sw, Action action, int iterations)
        {
            sw.Restart();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
    
            return sw.Elapsed.TotalMilliseconds;
        }
    }
    #endregion
