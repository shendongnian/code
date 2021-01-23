    public class Vars
    {
        public static Vars CPU = new Vars("CPU", 1);
        public static Vars RAM = new Vars("RAM", 2);
        
        public Vars(string name, int id)
        {
            ...
        }
    }
    public void Add(Vars variable, object value);
