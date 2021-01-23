    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var per = new Person();
                var perDict = new Dictionary<string, string>();
    
    
                foreach (
                    var c in 
                        per.GetType()
                            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                .ToDictionary(prop => prop.Name, prop => prop.GetValue(per,null))
                            )
                {
                    
                Console.Write("Greetings, Please Enter Your Value for: " + c.Key + " ");
                var answer = Console.ReadLine();
                perDict.Add(c.Key, answer);
                per.GetType().GetProperty(c.Key).SetValue(per,answer, null);
                }
            }
        }
    
    }
