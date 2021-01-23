    class Program
    {
        private static ArrayList arl;
        public static void Main(string[] args)
        {
            arl = new ArrayList();
            arl.Add("2.1/1");
            arl.Add("2.1/2");
            arl.Add("2.2");
            arl.Add("2.2/1");
            arl.Sort(new IDDSort());
            foreach (var value in arl)
            {
                Console.WriteLine(value);
            }
            Console.Read();           
        }
    }
    public class IDDSort : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == y) return 0;
            var xparts = x.ToString().Replace("/","").Split('.');
            var yparts = y.ToString().Replace("/", "").Split('.');
            var length = new[] { xparts.Length, yparts.Length }.Max();
            for (var i = 0; i < length; i++)
            {
                int xint;
                int yint;
                if (!Int32.TryParse(xparts.ElementAtOrDefault(i), out xint)) xint = 0;
                if (!Int32.TryParse(yparts.ElementAtOrDefault(i), out yint)) yint = 0;
                if (xint > yint) return 1;
                if (yint > xint) return -1;
            }
            //they're equal value but not equal strings, eg 1 and 1.0
            return 0;
        }
    }
