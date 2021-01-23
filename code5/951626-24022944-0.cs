    public void InitializeApp()
    {
        foreach(Type t in Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(ISomething<>).IsAssignableFrom(T)))
        {
            var methodInfo = typeof( Provider ).GetMethod( "RegisterType", BindingFlags.Static );
            var registerTypeMethod = methodInfo.MakeGenericMethod( t );
            registerTypeMethod.Invoke( null, new[] { Activator.CreateInstance(t) } );
        }
    }
