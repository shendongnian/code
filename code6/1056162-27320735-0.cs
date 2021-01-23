    class Program
        {
            public static void ArgsMethod(params object[] args) 
            {
                foreach (var par in args)
                 {
                     Console.WriteLine("variable has type: " + par.GetType() );
    
                 }
            }
    
            static void Main(string[] args)
            {
                Type[] types = new Type[1];
                types[0] = typeof(object[]);
                MethodInfo m = typeof(Program).GetMethod("ArgsMethod", types);
                object[] parameters = new Object[1];
                parameters[0] = args;
                m.Invoke(null, parameters);
            }
        }
