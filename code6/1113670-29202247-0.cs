    string mystring = "MonsterMMORPG";
            var sw = new Stopwatch();
            sw.Start();
            int count = 10000;
            var regex1 = @"=powered\ by\ 4images";
            for (int i = 0; i < count; i++)
            {
                
                if (Regex.IsMatch(mystring, regex1, RegexOptions.IgnoreCase))
                {
                }
            }
            sw.Stop();
            Console.WriteLine(string.Format("using Static Check:{0}", sw.Elapsed));
            sw = new Stopwatch();
            var r = new Regex(regex1,RegexOptions.IgnoreCase);
            sw.Start();
            for (int i = 0; i < count; i++)
            {
                if (r.IsMatch(mystring))
                {
                    
                };
            }
            sw.Stop();
            Console.WriteLine(string.Format("using instance Check:{0}", sw.Elapsed));
