        private _rules = new List<IRules>();
        public SomeConstructor()
        {
           _rules.Add(new RuleNumberOne());
           _rules.Add(new RuleNumberTwo());
        }
    
        public void DoSomething()
        {
           //Define some object to be pass here
           foreach(var rule in _rules)
           {
             rate = rule.Execute(object);
           }
        }
