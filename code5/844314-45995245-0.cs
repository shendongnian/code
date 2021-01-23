    using Newtonsoft.Json;
    
    namespace CastParentToChild
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var p = new parent();
                p.a=111;
                var s = JsonConvert.SerializeObject(p);
                var c1 = JsonConvert.DeserializeObject<child1>(s);
                var c2 = JsonConvert.DeserializeObject<child2>(s);
                
                var foreigner = JsonConvert.DeserializeObject<NoFamily>(s);
                
                bool allWorks = p.a == c1.a && p.a == c2.a && p.a == foreigner.a;
                //Your code goes here
                Console.WriteLine("Is convertable: "+allWorks + c2.b);
            }
        }
        
        public class parent{
            public int a;
        }
        
        public class child1 : parent{
         public int b=12345;   
        }
        
        public class child2 : child1{
        }
        
        public class NoFamily{
            public int a;
            public int b = 99999;
        }
        // Is not Deserializeable because
        // Error 'NoFamily2' does not contain a definition for 'a' and no extension method 'a' accepting a first argument of type 'NoFamily2' could be found (are you missing a using directive or an assembly reference?)
        public class NoFamily2{
            public int b;
        }
    }
