    public class SuperClass
    {
        object a;
        public SuperClass()
        {
            a = "123";
        }
        // you need to have this
        public SuperClass(SuperClass copy)
        {
            a = copy.a;
        }
    }
    public class InheritedClass : SuperClass
    {
        object b;
        public InheritedClass()
        {
            Init();
        }
        // and this
        public InheritedClass(SuperClass super): base(super)
        {
            // bacause you can't call base() and this()
            Init();
        }
        private void Init()
        {
            b = "456";
        }
    }
