        public abstract class BaseClass
        {
            public List<String> List { get; protected set; }
            protected BaseClass()
            {
                defineList();
                optionalDoSomething();
                doSomething();
            }
            protected void defineList()
            {
                // default implementation here
                List = new List<String>();
                internalDefineList();
            }
            protected void doSomething()
            {
                // default implementation here
                internalDoSomething();
            }
            protected void optionalDoSomething()
            {
                // default implementation here
                internalOptionalSomething();
            }
            protected virtual void internalDefineList()
            {
            }
            protected virtual void internalDoSomething()
            {
            }
            protected virtual void internalOptionalSomething()
            {
            }
        }
        public class DerivedClass : BaseClass
        {
            protected override void internalDefineList()
            {
                var list = List;
            }
            protected override void internalDoSomething()
            {
            }
            
            // this method is not required
            /*          
            protected override void internalOptionalSomething()
            {
            }
            */
        }
