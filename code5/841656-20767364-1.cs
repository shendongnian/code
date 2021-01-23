            Stopwatch s1 = new Stopwatch();
            List<string> source = new List<string>();
            Random rnd = new Random();
            for(int i = 0; i < 1000; i++)
            {
                var input = "I have a listbox in my windows form application that shows quite long texts. Since texts are so long, user have to use the horizontal slider for check the rest of text. So, I want to limit listbox character per line. For every 50 char it should go to next row, so user won't have to use glider.";
                int nextbreak = rnd.Next(20, input.Length);
                source.Add(new string(input.TakeWhile((x, y) => input.IndexOf(' ', y) <= nextbreak).ToArray()));
            }
            s1.Start();
            List<string> output = new List<string>(from s in source
                                                   from p in s.SplitByLength_LB(50)
                                                   select p);
            s1.Stop();
            Console.WriteLine("SplitByLength_LB\t" + s1.ElapsedMilliseconds.ToString());
            s1.Reset();
            s1.Start();
            List<string> output2 = new List<string>(from s in source
                                                    from p in s.SplitByLength_tinstaafl(50)
                                                    select p);
            s1.Stop();
            Console.WriteLine("SplitByLength_tinstaafl\t" + s1.ElapsedMilliseconds.ToString());
