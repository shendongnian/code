    using System;
    using System.Collections.Generic;
    
    namespace Example
    {
        public enum Prior
        {
            None,
            Moderate,
            Terminal
        };
    
        public abstract class ScriptBase
        {
            public abstract Prior Prior { get; }
    
            public abstract void Apply();
    
            public void Start(DataProvider dataProvider)
            {
                dataProvider.Subscribe(Prior, Apply);
            }
    
            public void Stop(DataProvider dataProvider)
            {
                dataProvider.Unsubscribe(Prior, Apply);
            }
        }
    
        public class ScriptHandlingModerateEvents : ScriptBase
        {
            public override Prior Prior
            {
                get { return Example.Prior.Moderate; }
            }
    
            public override void Apply()
            {
                Console.WriteLine("Handling moderate event by " + GetType().Name);
            }
        }
    
        public class ScriptHandlingTerminalEvents : ScriptBase
        {
            public override Prior Prior
            {
                get { return Example.Prior.Terminal; }
            }
    
            public override void Apply()
            {
                Console.WriteLine("Handling terminal event by " + GetType().Name);
            }
        }
    
        public class DataProvider
        {
            private readonly Dictionary<Prior, List<Action>> _subscribersByPrior;
    
            public DataProvider()
            {
                _subscribersByPrior = new Dictionary<Prior, List<Action>>();
    
                foreach (Prior prior in (Prior[])Enum.GetValues(typeof(Prior)))
                {
                    _subscribersByPrior.Add(prior, new List<Action>());
                }
            }
    
            public void Subscribe(Prior prior, Action action)
            {
                _subscribersByPrior[prior].Add(action);
            }
    
            public void Unsubscribe(Prior prior, Action action)
            {
                _subscribersByPrior[prior].Remove(action);
            }
    
            public void DoSomethingThatTriggersPriorEvents(int someValue)
            {
                Prior prior = someValue % 2 == 0 ? Prior.Moderate : Prior.Terminal;
                foreach (var subscriber in _subscribersByPrior[prior])
                {
                    subscriber();
                }
            }
        }
    
        public static class Program
        {
            public static void Main()
            {
                DataProvider dataProvider = new DataProvider();
    
                var scriptHandlingModerateEvents = new ScriptHandlingModerateEvents();
                scriptHandlingModerateEvents.Start(dataProvider);
    
                var scriptHandlingTerminalEvents = new ScriptHandlingTerminalEvents();
                scriptHandlingTerminalEvents.Start(dataProvider);
    
                for (int i = 0; i < 10; i++)
                {
                    dataProvider.DoSomethingThatTriggersPriorEvents(i);
                }
    
                scriptHandlingTerminalEvents.Stop(dataProvider);
                scriptHandlingModerateEvents.Stop(dataProvider);
    
                Console.WriteLine();
            }
        }
    }
