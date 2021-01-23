    public class MyClass()
    {
        private readonly IValidationRuleFactory _validationRuleFactory;
    
        public MyClass(IValidationRuleFactory validationRuleFactory)
        {
            _validationRuleFactory = validationRuleFactory;
        }
    
        public bool CheckValid()
        {
            var composite = _validationRuleFactory.CreateComposite();
            return composite.IsValid();
        }
    }
