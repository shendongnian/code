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
    		genericCreateMethod.Invoke(null, new[]{obj});
        }
    	
    	private static void CreateGeneric<T>(T obj)
        {
    		var generic = new Generic<T>();
    	}
    }
