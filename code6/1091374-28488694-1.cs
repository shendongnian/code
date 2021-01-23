    public class SomeDerivedClass : SomeBaseClass {
        public SomeDerivedClass(SomeType onlyOneInstance)
            : base(new[] { onlyOneInstance})
        {
        }
    }
