    public abstract class BazBase : IPlugin
    {
        public abstract ImplementationName ImplementationName {get;}
        protected virtual Regex FeaturePattern {get;}
        public abstract TryProvide(FeatureName name);
        protected virtual bool ImplementationNameTest(FeatureName name)
        {
            return name.ToString() == ImplementationName.ToString();
        }
        protected virtual bool FeaturePatternTest(FeatureName name)
        {
            return FeaturePattern != null && FeaturePattern.IsMatch(name.ToString());
        }
    }
    
