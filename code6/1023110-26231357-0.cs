    interface IMyRestriction
    {
       // use whichever arguments you wanted for construction
       void Init(string myParam1, string myParam2)
    }
    
    public class MyFactory<TProduct> : IFactory<TProduct>
        where TProduct: class, IMyRestriction, new()
    {
    
        public TProduct Create() {
           TProduct p = new TProduct(); 
            p.Init(arg1,arg2);
            return p;
        }
    
    }
