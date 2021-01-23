            string Mystring = "SimpleWordforExAmple";
            char[] chars;
            char ch;
            int length = Mystring.Length;
            int cnt;
            int totalcntupper = 0;
            chars = Mystring.ToCharArray(0, length);
            Console.WriteLine("Sample words with capital letters : {0} ", Mystring);
            for (cnt = 0; cnt < length;cnt ++)
            {
                ch = chars[cnt];
                if (char.IsUpper(ch))
                {
                    Console.WriteLine("Capital letter : #{0}", ch);
                    totalcntupper++;
                 
                }
            }
            Console.WriteLine("Count of capital letter(s) : # {0}", totalcntupper);
            Console.ReadLine();
            #endregion
