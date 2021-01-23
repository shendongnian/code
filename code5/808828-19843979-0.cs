using System.Reflection;
    private static readonly MethodInfo x_Execute_T = typeof(x).GetMethod("Execute", BindingFlags.Public | BindingFlags.Static);
    private static readonly MethodInfo BuildExecute_T = typeof(LoadUserControl).GetMethod("BuildExecute", BindingFlags.NonPublic | BindingFlags.Static);
    private readonly Func<object> x_Execute;
    public static Type typCreate;
    public LoadUserControl(Type t)
    {
        typCreate = t;
        x_Execute = (Func<object>)BuildExecute_T.MakeGenericMethod(t).Invoke(null, null);
    }
    
    private static Func<object> BuildExecute<T>()
    {
    	return () => ((Func<T>)Delegate.CreateDelegate(typeof(Func<T>), x_Execute_T.MakeGenericMethod(typeof(T))))();
    }
    
    protected void ButtonCommand( object sender, object e )
    {
       x_Execute();
    }
