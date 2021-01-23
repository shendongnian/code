            Dictionary<string, int> test1 = new Dictionary<string, int>();
            Random rnd = new Random();
            int stopint = rnd.Next(0, (int)(Math.Sqrt(10000000)/2));
            List<string> check = new List<string>();
            for(int i = 0; i < 10000000; i++)
            {
                StringBuilder sb = new StringBuilder();
                for(int j = 0; j < 30; j++)
                {
                    sb.Append((char)rnd.Next(33, 256));
                }
                if(i % stopint == 0)
                {
                    check.Add(sb.ToString());
                }
                test1.Add(sb.ToString(), i);
            }
            for(int i = 0; i < check.Count; i++)
            {
               int test = test1[check[i]];
            }
