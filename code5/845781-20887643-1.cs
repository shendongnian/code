    class Program
    {
        static void Main(string[] args)
        {
            string s = "yyyy-MM-dd";
            string reg = @"^\bdd/MM/yyyy\b$";
            string reg1 = @"^\byyyy-MM-dd\b$";
            if (Regex.IsMatch(s, reg))
                Console.WriteLine("true");
            else if (Regex.IsMatch(s, reg1))
                Console.WriteLine("true");
            // and so on..
            Console.ReadLine();
        }
    }
