        public abstract class BaseClass
        {
            public List<String> List { get; protected set; }
            protected BaseClass()
            {
                defineList();
                optionalDoSomething();
                doSomething();
            }
            protected abstract void internalDefineList();
            protected abstract void internalDoSomething();
            protected abstract void internalOptionalSomething();
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
            protected override void internalOptionalSomething()
            {
            }
        }
