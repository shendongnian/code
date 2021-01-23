    public class ValidationRuleFactory : IValidationRuleFactory
    {
        public IValidationRule CreateComposite()
        {
            var rules = CreateRules();
            return new ValidationRuleComposite(rules);
        }
    
        private IEnumerable<IValidationRule> CreateRules()
        {
            //return all other rules here.
            //I would hard code them and add new ones here as they are created.
            //If you don't want to do that you could use reflection.
        }
    }
