    public class FooBar
    {
        public abstract int GenerateId(string productCode);
    
        public void Save()
        {
           var fooBarId = this.GenerateId("myproduct");
           //fooBarId will be used in this code block
        }
    }
    public class AnotherFooBar : FooBar
    {
        public override int GenerateId(string productCode)
        {
           //..some logic to return an integer;
        }
    }
