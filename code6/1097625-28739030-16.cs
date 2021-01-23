    public interface IValidationRule
    {
        bool IsValid();
    }
    public interface IValidationRuleComposite : IValidationRule
    {
        void ValidationRuleCompose(List<IValidationRule> validationRules);
    }
