    using System;
    using System.Numerics;
    using System.Text;
    using Numerics;
    
    public class Program
    {
        public static BigRational ComputeP(int k, int n, int p)
        {
            // the P(n) equation
            BigRational pnNumerator = BigRational.Pow(p, n);
            BigRational pnDenominator = BigRational.Pow(k, (n - k)) * Factorial(k);
    
    
            // the P(0) equation
    
            //---the right side of "+" sign in Denominator
            BigRational pk = BigRational.Pow(p, k);
            BigRational factorialK = Factorial(k);
            // CHANGED: Don't cast to double here (loses precision)
            BigRational lastPart = (BigRational.Subtract(1, BigRational.Divide(p, k)));
            BigRational factorialAndLastPart = BigRational.Multiply(factorialK, lastPart);
            BigRational fullRightSide = BigRational.Divide(pk, factorialAndLastPart);
            //---the left side of "+" sign in Denominator
            BigRational series = Series(k, p);
    
    
            BigRational p0Denominator = series + fullRightSide;
            BigRational p0Result = BigRational.Divide(1, p0Denominator);
    
            BigRational pNResult = BigRational.Divide((pnNumerator * p0Result), pnDenominator);
            return pNResult;
        }
    
        // CHANGED: Removed n as parameter (n just the index of summation here)
        public static BigRational Series(int k, int p)
        {
            BigRational series = new BigRational(0.0);
            var fin = k - 1;
            // CHANGED: Should be <= fin (i.e. <= k-1, or < k) because it's inclusive counting
            for (int i = 0; i <= fin; i++)
            {
                var power = BigRational.Pow(p, i);
                // CHANGED: was Factorial(n), should be factorial of n value in this part of the sequence being summed.
                var factorialN = Factorial(i);
                var sum = BigRational.Divide(power, factorialN);
                series += sum;
            }
            return series;
        }
    
        public static BigRational Factorial(int k)
        {
            if (k <= 1)
                return 1;
            else return BigRational.Multiply(k, Factorial(k - 1));
        }
    
        static void Main(string[] args)
        {
            var k = 40;
            var n = 235;
            var p = 5;
            var result = ComputeP(k, n, p);
            Console.WriteLine(result.ToDecimalString(1000));
            Console.ReadKey();
        }
    }
    
    // From https://stackoverflow.com/a/10359412/4486839
    public static class BigRationalExtensions
    {
        public static string ToDecimalString(this BigRational r, int precision)
        {
            var fraction = r.GetFractionPart();
    
            // Case where the rational number is a whole number
            if (fraction.Numerator == 0 && fraction.Denominator == 1)
            {
                return r.GetWholePart() + ".0";
            }
    
            var adjustedNumerator = (fraction.Numerator
                                               * BigInteger.Pow(10, precision));
            var decimalPlaces = adjustedNumerator / fraction.Denominator;
    
            // Case where precision wasn't large enough.
            if (decimalPlaces == 0)
            {
                return "0.0";
            }
    
            // Give it the capacity for around what we should need for 
            // the whole part and total precision
            // (this is kinda sloppy, but does the trick)
            var sb = new StringBuilder(precision + r.ToString().Length);
    
            bool noMoreTrailingZeros = false;
            for (int i = precision; i > 0; i--)
            {
                if (!noMoreTrailingZeros)
                {
                    if ((decimalPlaces % 10) == 0)
                    {
                        decimalPlaces = decimalPlaces / 10;
                        continue;
                    }
    
                    noMoreTrailingZeros = true;
                }
    
                // Add the right most decimal to the string
                sb.Insert(0, decimalPlaces % 10);
                decimalPlaces = decimalPlaces / 10;
            }
    
            // Insert the whole part and decimal
            sb.Insert(0, ".");
            sb.Insert(0, r.GetWholePart());
    
            return sb.ToString();
        }
    }
