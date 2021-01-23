    string Note = "hello";
            char[] Newspaper = "ahrenlxlpoz".ToCharArray();
            string res = "";
            for (int i = 0; i < Note.Length; i++)
                for (int j = 0; j < Newspaper.Length; j++)
                    if (Note[i] == Newspaper[j])
                    {
                        res += Newspaper[j];
                        Newspaper[j] = ' ';
                        break;
                    }
            //This prints the remaining characters in Newspaper. I avoid repeating chars.
            for (int i = 0; i < Newspaper.Length; i++ )
                Console.Write(Newspaper[i]+"\n");
            Console.Write("\n\n");
            if (Note.Equals(res)) Console.Write("Word found");
            else Console.Write("Word NOT found");
            Console.Read();
