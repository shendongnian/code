    public abstract class Base
    {
       public virtual int GetResult(int data)
       {
           var z = GetMoreData();
           return data*z;
       }
       protected int GetMoreData()
       {
          ///something
          return something;
        }
    }
    
    public class MyRealImplementation : Base
    {
        public override int GetResult(int data)
        {
           //wahtever
        }
    }
