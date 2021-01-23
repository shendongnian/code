    class Base
    {
        public virtual void Foo()
        {
            Console.WriteLine("base");
        }
    }
    class Derived : Base
    {
        public override void Foo()
        {
            Console.WriteLine("derived");
        }
        //// bad
        //public Base MyBase
        //{
        //    get
        //    {
        //        return base; // Use of keyword 'base' is not valid in this context
        //    }
        //}
        // work but...
        public Base MyBase
        {
            get
            {
                return (Base)this;
            }
        }
    }
