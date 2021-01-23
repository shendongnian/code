    public interface IFooClassProvider
    {
        FooClass CreateFooClass(MyContainer container, int d, int e, int f);
    }
    public interface IMyContainerProvider
    {
        MyContainer CreateMyContainer(int a, int b, int c);
    }
    public MyClass
    {
        private IMyContainerProvider _myContainerProvider;
        private IFooClassProvider _fooClassProvider;
        public MyClass(IMyContainerProvider myContainerProvider, IFooClassProvider fooClassProvider)
        {
            _myContainerProvider = myContainerProvider;
            _fooClassProvider = fooClassProvider;
        }
        ...
        public bool MyMethod(int a, int b, int c, out FooClass foo)
        {
           var someContainer = _myContainerProvider.CreateMyContainer(a,b,c);
           foo = _fooClassProvider.CreateFooClass(someContainer,1,2,3);
           ...
           return true;
        }
        ...
    }
