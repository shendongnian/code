    static class Program
    {
        public class ActionWithDelay
        {
            public Action Work { get; set; }
            public TimeSpan DelayAfter { get; set; }
        }
        public static async Task Run(IEnumerable<ActionWithDelay> actions)
        {
            foreach (var action in actions)
            {
                action.Work();
                await Task.Delay(action.DelayAfter);
            }
        }
        static void Main()
        {
            var actions = new[]
            {
                new ActionWithDelay { Work = () => Console.WriteLine("Step 1"), DelayAfter = TimeSpan.FromSeconds(10) },
                new ActionWithDelay { Work = () => Console.WriteLine("Step 2"), DelayAfter = TimeSpan.FromSeconds(5) },
                new ActionWithDelay { Work = () => Console.WriteLine("Step 3"), DelayAfter = TimeSpan.FromSeconds(5) },
                new ActionWithDelay { Work = () => Console.WriteLine("Step 4"), DelayAfter = TimeSpan.FromSeconds(10) },
            };
            Run(actions).Wait();
            Console.WriteLine("Done");
            Console.Read();
        }
    }
