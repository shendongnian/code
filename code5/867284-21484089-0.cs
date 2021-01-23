     static Dictionary<char, string> Mapping =
         new Dictionary<char, string>() 
             { { 'a', "alpha" }, { 'b', "beta" }, { 'c', "gamma" }, { 'd', "zeta" } };
        
        static void Main(string[] args)
        {            
            string test = "abcx";
            Console.WriteLine(string.Join(" ", test.Select(t => GetMapping(t))));  
            //output alpha beta gamma not found         
            Console.ReadKey();
        }
                
        static string GetMapping(char key)
        {
            if (Mapping.ContainsKey(key))
                return Mapping.First(a => a.Key == key).Value;
            else
                return "not found";            
        }      
