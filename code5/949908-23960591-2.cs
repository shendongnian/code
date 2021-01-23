    public static class ActionExtensions
    {
    	public static Func<T, T> ToFunc<T>(this Action<T> act)
        {
            return a => { act(a); return default(T) /*or a*/; };
        }
    }
    Action<?> act = ...;
    SomeMethod(act.ToFunc());
