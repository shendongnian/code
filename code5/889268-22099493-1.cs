    public class Class2
    {
        private Class1 _dependency;       
        public Class2(Class1 dependency)
        {
             _dependency = dependency;
        }
        public void Whatever()
        {
             _dependency.MyList;
        }
    }
