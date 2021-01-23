    string Note = "hello";
            string Newspaper = "ahrenlxlpoz";
            string res = "";
            for (int i = 0; i < Note.Length; i++)
                for (int j = 0; j < Newspaper.Length; j++)
                    if (Note[i] == Newspaper[j])
                    {
                        res += Newspaper[j];
                        break;
                    }
