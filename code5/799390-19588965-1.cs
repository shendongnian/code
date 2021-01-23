    public class ReverseComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
         return y.CompareTo(x); //Here the logic will crash since trying to compare with   null value and hence throw NullReferenceException
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
                Array.Sort(dinosaurs, rc); //Out from here the NullReferenceException propagated as InvalidOperationException.
            }
            catch (Exception)
            {
    
                throw;
            }
    
        }
    }
