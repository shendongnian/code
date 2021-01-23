    public class BaseClass
    {
        public int Id;
        public DateTime Date;
    }
    
    class Type1: BaseClass
    {
    		
    
    }
    
    class Type2 : BaseClass
    {
    
    
    }
    
    public class BaseClassComparer : IEqualityComparer<BaseClass>
    {
        #region IEqualityComparer<BaseClass> Members
    
        public bool Equals( BaseClass x, BaseClass y )
        {
            return x.Id == y.Id && x.Date == y.Date;
        }
    
        public int GetHashCode( BaseClass obj )
        {
            return obj.GetHashCode ();
        }
    
        #endregion
    }
