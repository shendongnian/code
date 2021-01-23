    string text = Console.ReadLine();
            char[] delimiterChars = { ' ' };
            string[] words = text.Split(delimiterChars);
            foreach (string s in words)
            {
                char[] chars = s.ToCharArray();
                chars[0] = char.ToUpper(chars[0]);
                if (chars.Length > 2)
                {
                    chars[2] = char.ToUpper(chars[2]);
                }
                Console.Write(new string(chars));
                Console.Write(' ');
            }
            Console.ReadKey();
