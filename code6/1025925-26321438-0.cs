        static void Main(string[] args)
        {
            string a = "12223";
            string b = "P12345";
            bool z = Regex.IsMatch(a,@"(.)\1");
            bool x = Regex.IsMatch(b,@"(.)\1");
                         
        }
