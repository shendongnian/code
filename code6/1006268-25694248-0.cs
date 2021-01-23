    class Fraction
    {
         public int Numerator { get; set; }
         public int Denominator { get; set; }
         public double Value { get { return ((double) Numerator)/Denominator; } }
         public void ToString()
         {
             string ret = "";
             int whole = Numerator / Denominator;
             if( whole != 0 )
                 ret += whole + " ";
             ret += (Numerator % Denominator) + "/" + Denominator;
         }
   } 
