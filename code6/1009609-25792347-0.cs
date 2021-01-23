    public class Parser
    {
        readonly List<Tuple<Regex, Action>> actions = new List<Tuple<Regex, Action>>();
        public Parser()
        {
            Add(@"^0$", () => { DoSomething(); });
            Add(@"^DoSomething$", () => { DoSomething(); });
            Add(@"^1$", () => { DoSomethingElse() });
            Add(@"^DoSomethingElse$", () => { DoSomethingElse() });
          
            // etc
        }
        private void Add(string regex, Action action)
        {
            var key = new Regex(regex, RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            actions.Add(Tuple.Create(key, action));
        }
        public void Parse(string text)
        {
            foreach (var action in actions)
            {
                var collection = action.Item1.Matches(text);
                try
                {
                    action.Item2();
                }
                catch (Exception e)
                {
                    // log?
                    throw;
                }
            }
        }
    }
