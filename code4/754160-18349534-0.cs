    class Weight
    {
        private double ounces;
        private const double OUNCES_PER_POUND = 16.0;
    
        public double Pounds
        {
            get { return ounces / OUNCES_PER_POUND; }
        }
        public double Ounces
        {
            get { return ounces; }
        }
    
        public Weight(double pounds)
        {
            this.ounces = pounds * OUNCES_PER_POUND;
        }
        public Weight(int pounds, double ounces)
        {
            this.ounces = pounds * OUNCES_PER_POUND + ounces;
        }
    
        // An example operator, probably want to implement addition
        // and perhaps multiplication/division as well
        public static Weight operator -(Weight w1, Weight w2)
        {
            return new Weight((w1.ounces - w2.ounces) / OUNCES_PER_POUND);
        }
    
        public override string ToString()
        {
            return String.Format("{0} pounds, {1} ounces", (int)Pounds, Math.Round(Ounces % OUNCES_PER_POUND, 4));
        }
    }
    
    class Program
    {
        public static void Main()
        {
            var w1 = new Weight(151.10);
            var w2 = new Weight(142.19);
            Console.WriteLine("w1: " + w1.ToString() );         // 151 pounds, 1.6 ounces
            Console.WriteLine("w2: " + w2.ToString() );         // 142 pounds, 3.04 ounces
            Console.WriteLine("diff: " + (w1 - w2).ToString()); //   8 pounds, 14.56 ounces
        }
    }
