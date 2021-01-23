    public enum DefType
    {
        BaseDef = 0,
        ADef =1,
        BDef =2
    }
    public class BaseDef
    {
        public virtual DefType MyType
        {   
            get{ return  DefType.BaseDef; }
        }
    }
    public class ADef
    {
        public override DefType MyType
        {   
            get{ return  DefType.ADef; }
        }
    }
