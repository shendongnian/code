	public class ManagerClass
    {
        // This is a singleton class.
        static ManagerClass instance;
		private static Func<BaseClassFunctionHolder, BaseClass> _createBaseClass;
		
        public static T CreateBaseClass<T>() where T : BaseClass, new()
        {
            // Create and return a BaseClass.
            // Everything in BaseClass should be accessible here.
			
			//example
			BaseClassFunctionHolder holder = new BaseClassFunctionHolder();
			T baseClass = _createBaseClass(holder);
			
			//access to baseClass methods through holder.DoStuff, and holder.DoOtherStuff
			return baseClass;
        }
		
		private class BaseClassFunctionHolder
		{
			public Action DoStuff { get; set; }
			public Action DoOtherStuff { get; set; }
		}
        abstract class BaseClass
        {
			static BaseClass()
			{
				_createBaseClass = (holder) => new BaseClass(holder);
			}
			
			private BaseClass(BaseClassFunctionHolder holder)
			{
				holder.DoStuff = DoStuff;
				holder.DoOtherStuff = DoOtherStuff;
			}
			
            public bool IsRunning { get; set; }
            virtual void DoStuff()
            {
                // Do stuff.
            }
            abstract void DoOtherStuff();
        }
    }
    public class DerivedClass : ManagerClass.BaseClass
    {
        override void DoStuff()
        {
            // Do stuff.
        }
        override void DoOtherStuff()
        {
            // Do other stuff.
        }
    }
    class TestClass
    {
        static void Main(string[] args)
        {
            // Assume singleton is already created here.
            BaseClass bc = ManagerClass.CreateBaseClass<DerivedClass>();
            // bc.IsRunning should be accessible
            // bc.DoStuff() and DoOtherStuff() should not be accessible
        }
    }
