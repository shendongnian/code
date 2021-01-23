        static void Main( )
        {
            string[] ss = { "a", "b" };
            Dictionary<string, del> dic = new Dictionary<string, del >();
            foreach (string s in ss)
            {
                dic[s] = (sr) => sr;
            }
            foreach (string s in ss)
            {
                System.Console.WriteLine("{0}:{1}", s, dic[s].Invoke(s));
            }
            System.Console.ReadLine();
        }
