    class Base
    {
        int _i = 0;
        public virtual int i
        {
            get { return _i; }
        }
    
        public String sayIt()
        {
            return Convert.ToString(this.i);
        }
    }
    
    class Derived : Base
    {
        int _i = 1;
        public override int i
        {
            get { return _i; }
        }
    }
