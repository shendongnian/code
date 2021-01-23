    class Program
        {
            static void Main(string[] args)
            {
                char[] list = { '\"' };
                string response = "\"bla\"";
                response = response.Trim(list);
    
                Console.WriteLine(response);
                Console.ReadLine();
            }
        }
