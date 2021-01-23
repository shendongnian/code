        static void Main(string[] args)
        {
            string phone = "11122223333";
            string pattern = @"(\d{3})(\d{4})(\d{4})";
            string replace = "($1) $2 $3";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(phone, replace);
            Console.WriteLine(result); 
        }
