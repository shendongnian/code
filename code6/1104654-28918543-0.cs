    class Program
        {
            public static void Main(string[] args)
            {
                var dictionary = new Dictionary<string, TypeCreator>();
                dictionary.Add("A", new TypeCreator(typeof(CustomA),"parameter1"));
                dictionary.Add("B", new TypeCreator(typeof(CustomB), "parameter1", "parameter2"));
    
                var instance = dictionary["A"].GetInstance();
            }        
        }
    
        public class TypeCreator
        {
            public TypeCreator(Type type, params object[] args)
            {
                CustomType = type;
                Params = args;
            }
            public Type CustomType { get; set; }
            public object[] Params { get; set; }
    
            public Object GetInstance()
            {
                return Activator.CreateInstance(CustomType, Params);
            }
        }
    
        public class CustomA
        {
            public CustomA(string param1)
            {
    
            }
        }
    
        public class CustomB
        {
            public CustomB(string param1, string param2)
            {
    
            }
        }
