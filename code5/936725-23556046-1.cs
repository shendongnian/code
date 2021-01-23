        public class MyClass1 : Base, INotBaseClassFunctionsProvider 
        {
            // base class implementation, note that this is not a good
            // coding practise, having a modifier that does not alter the output of the accessor
            // will likely cause headaches for someon down the track, make sure you 
            // document the reason why you have done this, if you ever do it.
            // Using interfaces we can remove the need to implement this base functionality altogether
            private MySubClass1 subClass1 = new MySubClass1();
            public override Base.MySubClass subClass
            {
                get
                {
                    return this.subClass1;
                }
                set
                {
                    base.MySubClass = this.subClass1;
                }
            }
            // INotBaseClassFunctionsProvider implementation
            public INotBaseClassFunctions GetSubclass()
            {
                return this.subClass1;
            }
            public class MySubClass1 : Base.MySubClass, INotBaseClassFunctions
            {
                public override string SaySomethingElse() { return "Something Else :)"; }
            }
        }
    
        public abstract class Base
        {
            public virtual MySubClass subClass { get; set; }
            public abstract class MySubClass
            {
                public string Hello() {return "hello";}
            }
        }
