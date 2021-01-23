        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            string original = "leite";
            string[] splitwords = new string[] { "leitelho", "leite", "One" };
            original = " " + original + " ";
            builder.Append(@"{\rtf1\ansi");
            foreach (string word in splitwords)
            {
                if (Regex.IsMatch(original, @"(?<![\w])" + word + @"(?![\w])"))
                {
                    //do domething
                    builder.Append(original);
                    builder.Append(@"}");
                    Console.Write(builder.ToString());
                    return;
                }
           }
        }
