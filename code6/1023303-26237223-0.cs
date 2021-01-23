    class Program
        {
            private static ArrayList arl;
    
            public static void Main(string[] args)
            {
                arl=new ArrayList();
    
                arl.Add("1.1");
                arl.Add("2.15");
                arl.Add("2.1");
               
               arl.Sort(new NumericStringSort());
                foreach (var value in arl)
                {
                    Console.WriteLine(value);
                }
                Console.Read();
            }       
        }
    
        public class NumericStringSort : IComparer
        {
            public int Compare(object a, object b)
            {
                decimal aDec;
                decimal bDec;
                if (decimal.TryParse((string) a, out aDec) && decimal.TryParse((string) b, out bDec))
                {
                    return aDec.CompareTo(bDec);
                }
                return 0;
            }       
        }
