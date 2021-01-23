    public class ReverseComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
         return y.CompareTo(x);
        }
    }
    
    public class Example
    {
        public static void Main()
        {
            string[] dinosaurs =
                {
                   "Amargasaurus",
                    null,
                    "Mamenchisaurus",
                   
                };
    
            Console.WriteLine();
            foreach (string dinosaur in dinosaurs)
            {
                Console.WriteLine(dinosaur);
            }
    
            ReverseComparer rc = new ReverseComparer();
    
            Console.WriteLine("\nSort");
            try
            {
                Array.Sort(dinosaurs, rc);
            }
            catch (Exception)
            {
    
                throw;
            }
    
        }
    }
