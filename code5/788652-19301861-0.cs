    abstract class FooActivator<T> where T : class
    {
        protected abstract Func<Foo, Bar<T>> ChosenProperty { get; }
    
        public void Activate(T param)
        {
    	    var foo = new Foo();
            ChosenProperty(foo).Method(param);
        }
    }
    
    class MyClassFooActivator : FooActivator<MyClass>
    {
    	protected override Func<Foo, Bar<MyClass>> ChosenProperty
    	{
    		get { return x => x.SomeBarMyClassProperty; }
    	}
    }
