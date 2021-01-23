    
    interface IFoo { }
	class A : IFoo { }
	class B : IFoo
	{
		public B(IFoo x) { }
	}
	class C : IFoo
	{
		public C(IFoo x) { }
    }
    var container = new SimpleContainer();
	container.Singleton<IFoo, A>();
	container.Decorate<IFoo, B>();
	container.Decorate<IFoo, C>();
	
    var foo = container.GetInstance<IFoo>();
	Assert.True(foo is C);
