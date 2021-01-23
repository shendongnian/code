    public abstract class BaseContainer<TProduct>
    {
        public TProduct Product { get; set; }
        public abstract void DoProcess();
    }
    
    public class MyContainer : BaseContainer<ProductOne>
    {
        public override void DoProcess()
        {
            Product.Feature.Execute();
        }
    }
