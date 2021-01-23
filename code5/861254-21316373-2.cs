    public class GrandChildClass : MyDerivedClass
    {
        public override void AnotherMethod()
        {
            // ERROR - AnotherMethod isn't virtual
        }
        public override void SomeMethod()
        {
            // ERROR - we sealed SomeMethod in MyDerivedClass
            // If we hadn't - this would be perfectly fine
        }
    }
