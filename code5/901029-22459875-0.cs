    public abstract class FooBar
    {
        protected abstract string Product { get; }
        private int GenerateId(string productCode)
        {
           //..some logic to return an integer;
        }
        
        public void Save()
        {
           var fooBarId = this.GenerateId(Product);
           SaveInternal(fooBarId);
        }
        
        protected abstract void SaveInternal(int id);
    }
    
    public class AnotherFooBar : FooBar
    {
        protected override string Product { get { return "myproduct"; } }
        protected override void SaveInternal(int id)
        {
           // id will be used in this code block
        }
    }
