    string s = "ConfigService";
                if (s != string.Empty && char.IsUpper(s[0]))
                {
                  s=  char.ToLower(s[0]) + s.Substring(1);
                }
                Console.WriteLine(s);
