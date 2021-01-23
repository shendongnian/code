	public interface IValidationRuleCompositeConstr : IValidationRule
	{
	
	}
	public class ValidationRuleCompositeOriginal : IValidationRuleCompositeConstr
	{
	    private readonly IEnumerable<IValidationRule> _validationRules;
	
	    public ValidationRuleCompositeOriginal(IEnumerable<IValidationRule> validationRules)
	    {
	        _validationRules = validationRules;
	    }
	
	    public bool IsValid()
	    {
	        return _validationRules.All(x => x.IsValid());
	    }
	}
