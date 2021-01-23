    abstract class Module
    {
        public Options Params { get; protected set; }
    }
    abstract class Options { }
    
    class MyModule : Module
    {
        public MyOptions MyParams
        {
            get
            {
                if (Params == null) Params = new MyOptions();
                return Params as MyOptions;
            }
        }
    }
    
    class MyOptions : Options
    {
        public string Param1;
    }
