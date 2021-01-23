    public class Foo
    {
        public void DoSomething()
        {
            DoSomething(this);
        }
    
        private static void DoSomething(object obj)
        {
    		Type runtimeType = obj.GetType();
    		MethodInfo createMethod = typeof(Foo).GetMethod("CreateGeneric", BindingFlags.Static | BindingFlags.NonPublic);
    		var genericCreateMethod = createMethod.MakeGenericMethod(runtimeType);
    		genericCreateMethod.Invoke(null, null);
        }
    	
    	private static void CreateGeneric<T>()
        {
    		var generic = new Generic<T>();
    		Console.WriteLine(typeof(T).Name);
    	}
    }
