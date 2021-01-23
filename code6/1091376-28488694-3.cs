    public class SomeDerivedClass : SomeBaseClass {
        public SomeDerivedClass(SomeType onlyOneInstance)
            : base(onlyOneInstance != null ? new [] { onlyOneInstance} : null)
        {
        }
    }
