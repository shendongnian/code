    public class WindowRuleBuilder
    {
        private IList<IWindowRule> rules;
        public WindowRuleBuilder(IList<IWindowRule> rules = null)
        {
            rules = rules ?? new List<IWindowRule>();
        }
        public WindowRuleBuilder AddRule(IWindowRule newRule)
        {
            rules.Add(newRule);
            return this;
        }
        public void Run(string command)
        {
            foreach (IWindowRule rule in rules)
            {
                if (rule.Command == command) rule.Invoke();
            }
        }
    }
