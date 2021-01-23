    abstract class BaseObj
    {
        public abstract double Cost { get; set; };
        public abstract double Rate{ get; set; }
        //...
    }
    
    class Obj1Wrapper : BaseObj
    {
        private Obj1 _obj;
    
        public Obj1Wrapper(Obj1 obj)
        {
            this._obj = obj;
        }
        
        public override double Cost
        {
            get
            {
                return this._obj.Cost;
            }
            set
            {
                this._obj.Cost = value;
            }
         };
    
        public override double Rate
        {
            get
            {
                return this._obj.Rate;
            }
            set
            {
                this._obj.Rate= value;
            }
         };
    
         //...
    
        public static implicit operator BaseObj(Obj1 obj)
        {
            return new Obj1Wrapper(obj); 
        }
    }
    
    class Obj2Wrapper : BaseObj
    {
        private Obj2 _obj;
    
        public Obj2Wrapper(Obj2 obj)
        {
            this._obj = obj;
        }
        
        public override double Cost
        {
            get
            {
                return this._obj.Cost;
            }
            set
            {
                this._obj.Cost = value;
            }
         };
    
        public override double Rate
        {
            get
            {
                return this._obj.Rate;
            }
            set
            {
                this._obj.Rate= value;
            }
         };
    
         //...
    
            public static implicit operator BaseObj(Obj2 obj)
        {
            return new Obj2Wrapper(obj); 
        }
    }
