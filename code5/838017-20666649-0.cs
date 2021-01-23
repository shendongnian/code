    static void Main(string[] args)
        {
            string exp = "New York, NY is where I live. Boston, MA is where I live. Kentwood in the Pines, CA is where I live.";
            string reg = @"[\w\s]*(?=,)";
            var matches = Regex.Matches(exp, reg);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.ToString());
            }
    
            Console.ReadLine();
        }
