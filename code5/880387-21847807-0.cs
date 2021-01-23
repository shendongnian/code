        static void Main(string[] args)
        {
            var d = new List<string>() { "7020_8", "7030_5", "7020_23", "7020_1", "7030_1" };
            
            Console.WriteLine("In:");
            foreach (string s in d)
                Console.WriteLine(s);
            Console.WriteLine();
            Console.WriteLine("Sorted Out:");
            foreach (string s in d.OrderBy(f => f, new MyComparer()))
                Console.WriteLine(s);
            Console.ReadLine();
        }
        internal class MyComparer : IComparer<string>
        {
            #region IComparer<string> Members
            public int Compare(string x, string y)
            {
                //return <0 if x < y, 0 if x = y, >0 if x > y
                //if the strings are equal return 0 now
                if (x.CompareTo(y) == 0)
                    return 0;
                int x1, x2;
                int y1, y2;
                //split the strings on _
                x1 = Convert.ToInt32(x.Split('_')[0]);
                x2 = Convert.ToInt32(x.Split('_')[1]);
                y1 = Convert.ToInt32(y.Split('_')[0]);
                y2 = Convert.ToInt32(y.Split('_')[1]);
                //compare the first part
                if (x1.CompareTo(y1) == 0)
                    //first parts are equal so compare the second
                    return x2.CompareTo(y2);
                else
                    return x1.CompareTo(y1);
            }
            #endregion
        }
