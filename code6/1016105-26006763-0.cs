    static void Main(string[] args)
            {
    
                var frac = new fraction(1,5); 
             
                Console.WriteLine(frac);
               Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
 
    public class fraction
        {
            public int nom { get; set; }
            public int denom { get; set; }
            public fraction(int n, int d)
            {
                nom = n;
                denom = d;
    
            }
    
            public override string ToString()
            {
                return string.Format("{0}\\{1}", nom, denom);
            }
        }
