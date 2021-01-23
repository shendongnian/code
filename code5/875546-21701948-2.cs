    public class Vars
    {
        public static Vars CPU = Vars.Get("CPU", 1);
        public static Vars RAM = Vars.Get("RAM", 2);
        
        //You can keep one of the params, name or id
        private Vars(string name, int id)
        {
            ...
        }
        
        public static Vars Get(string name, int id)
        {
            //check if id or name exists in static dictionary, and return that instance or create new one
        }
    }
    public void Add(Vars variable, object value);
