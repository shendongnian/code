        class Program : AbstractClass, Interface//, BaseClass
        {
            AbstractClass obj = new Program();
            //creating object of Program class and store reference to them in obj variable with AbstractClass type -> have access to program2() and add()
            Interface onj2 = new Program();
            //creating object of Program class and store reference to them in obj2 variable with Interface type -> have access to sub() only
            BaseClass b = new BaseClass();
            //just create object of BaseClass class
            
            //BaseClass b2 = new Program();
            //it is imposible, Program not IS BaseClass here
            public override void add()
            {
                throw new NotImplementedException();
            }
            public void sub()
            {
                throw new NotImplementedException();
            }
            static void Main(string[] args)
            {
            }
        }
        public abstract class AbstractClass
        {
            public void program2()
            {
            }
            public abstract void add();
        }
        interface Interface
        {
            void sub();
        }
        class BaseClass
        {
            public void div()
            {
                Console.WriteLine("base class method");
            }
        }
    }
