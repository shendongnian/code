    double freqMHz= freqkHz.MulRound(0.001); // freqkHz*0.001
    double amountEuro= amountEuro.AddRound(delta); // amountEuro+delta
 
        public static double AddRound(this double d,double val)
        {
            return double.Parse(string.Format("{0:g14}", d+val));
        }
        public static double MulRound(this double d,double val)
        {
            return double.Parse(string.Format("{0:g14}", d*val));
        }
