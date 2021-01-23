    using Microsoft.FxCop.Sdk;
 
    namespace MyCustomFxCopRules
    {
    
        internal abstract class BaseFxCopRule : BaseIntrospectionRule
        {
            protected BaseFxCopRule(string ruleName) 
                : base(ruleName, "DukesFirstFxCopRule.DukesFirstFxCopRule", typeof(BaseFxCopRule).Assembly)
            {
                ....
            }
        }
    }
