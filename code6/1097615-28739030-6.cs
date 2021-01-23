    public class ValidationRuleComposite : IValidationRuleComposite
    {
    	
    private List<IValidationRule> _validationRules;
    public void ValidationRuleCompose(List<IValidationRule> validationRules)
    {
    	_validationRules = validationRules;
    }
    public ValidationRuleComposite()
    {
    	_validationRules = new List<IValidationRule>();
    }
    public bool IsValid()
    {
    	Debug.WriteLine("Composite Valide");
    	return _validationRules.All(x => x.IsValid());
    	
    }
    
    }
