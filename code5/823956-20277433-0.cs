    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string str1="fire";
                string str2 = "fire";
                foreach(char obj in str1)
                if(str2.Contains(obj.ToString()))
                {
                    Console.WriteLine(obj);
                    Console.ReadLine();
                }
                Console.ReadLine();
    
            }
    
        }
    
    }
