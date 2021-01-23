        static void Test2()
        {
            foreach (string item in SO2588078())
            {
                Console.WriteLine(item);
            }
            string input = "a4726e1e-babb-4898-a5d5-e29d2bc40028;POPULATE DATA AØ99c1d133-15f5-4ef5-bc59-  d9ed673b70c6;POPULATE DATA BØ";
            string regex = "(;.*?Ø)";
            string output = Regex.Replace(input, regex, ";Ø");
            if (output == string.Join(";Ø", SO2588078()) + ";Ø")
            {
                Console.WriteLine("TRUE");
            }
        }
