    public class ValidationRuleComposite : IValidationRuleComposite
    {
    	
    private List<IValidationRule> _validationRules;
    public void ValidationRuleCompose(List<IValidationRule> validationRules)
    {
    	_validationRules = _validationRules.Union(validationRules).ToList();
    }
    public ValidationRuleComposite()
    {
    	_validationRules = new List<IValidationRule>();
    }
    public bool IsValid()
    {
    	Debug.WriteLine("Composite Valid");
    	return _validationRules.All(x => x.IsValid());
    	
    }
    
    }
