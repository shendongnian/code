    using System;
    namespace Demo
    {
        class BaseClass
        {
            protected string bla;
            public virtual string Bla
            {
                get
                {
                    return this.bla;
                }
                set
                {
                    this.bla = value;
                }
            }
            protected BaseClass()
            {
            }
            public BaseClass(string _bla)
            {
                this.Bla = _bla;
            }
        }
        class ChildClass: BaseClass
        {
            private string bla2;
            public override string Bla
            {
                get
                {
                    return bla2;
                }
                set
                {
                    bla2 = value;
                }
            }
            public ChildClass(string _bla2)
                : base("AAA")
            {
                // Step into the next line of code in the debugger.
                // You'll see that it goes into the ChildClass.Bla setter.
                // However note that this is making a virtual call in a constructor 
                // - which is very bad if there is a further derived class because
                // it will call a method in that derived class before that derived
                // class has been constructed.
                // You can fix this potential problem by making this entire class
                // sealed or by making the property sealed in this class.
                this.Bla = _bla2; 
            }
        }
        class Program
        {
            private void run()
            {
                var c = new ChildClass("X");
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
