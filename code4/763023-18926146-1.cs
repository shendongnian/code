    public abstract class FooBase : BazBase, IFoo
    {
        public virtual bool TryProvide(FeatureName name)
        {
            return ImplementationNameTest(name) || FeaturePatternTest(name);
        }
    }
