    #region Restriction Types
    public class MyRestriction : IMyRestriction {
        public MyRestriction(IArgumentType1 arg1, IArgumentType2 arg2) {
            ...
        }
    }
    
    public class MyDerivedRestriction : MyRestriction {
        public MyDerivedRestriction()
            : base(null, null)
        {
        }
    }
    #endregion
    
    #region Factory interface
    public interface IFactory<TProduct>
        where TProduct: class, IMyRestriction
    {
        TProduct Create();
    }
    #endregion
    
    #region Factory implementations for each entity
    public class MyRestrictionFactory : IFactory<MyRestriction>
    {
        public MyRestriction Create()
        {
            // args provided by factory constructor
            return new MyRestriction(arg1, arg2); 
        }
    }
    
    public class MyDerivedRestrictionFactory : IFactory<MyDerivedRestriction>
    {
        public MyDerivedRestriction Create()
        {
            return new MyDerivedRestriction(); 
        }
    }
    #endregion
