    /// <summary>
    /// Represents a rational number with 64-bit signed integer numerator and denominator.
    /// </summary>
    [Serializable]
    public struct RationalNumber : IComparable, IFormattable, IConvertible, IComparable<RationalNumber>, IEquatable<RationalNumber>
    {
         private const int MAXITERATIONCOUNT = 20;
         public RationalNumber(long numerator, long denominator) {...}
         public RationalNumber(RationalNumber numerator, RationalNumer denominator) {...}
         
         ...
         /// <summary>
         /// Adds two rational numbers.
         /// </summary>
         /// <param name="left">The first value to add.</param>
         /// <param name="right">The second value to add.</param>
         /// <returns>The sum of left and right.</returns>
         public static RationalNumber operator +(RationalNumber left, RationalNumber right)
         {
             //First we try directly adding in a checked context. If an overflow occurs we use the least common multiple and return the result. If it overflows again, it
             //will be up to the consumer to decide what he will do with it.
             //Cost penalty should be minimal as adding numbers that cause an overflow should be very rare.
             RationalNumber result;
             try
             {
                 long numerator = checked(left.numerator * right.Denominator + right.numerator * left.Denominator);
                 long denominator = checked(left.Denominator * right.Denominator);
                 result = new RationalNumber(numerator,denominator);
             }
             catch (OverflowException)
             {
                 long lcm = RationalNumber.getLeastCommonMultiple(left.Denominator, right.Denominator);
                 result = new RationalNumber(left.numerator * (lcm / left.Denominator) + right.numerator * (lcm / right.Denominator), lcm);
             }
             return result;
         }
         private static long getGreatestCommonDivisor(long i1, long i2)
         {
            Debug.Assert(i1 != 0 || i2 != 0, "Whoops!. Both arguments are 0, this should not happen.");
            //Division based algorithm
            long i = Math.Abs(i1);
            long j = Math.Abs(i2);
            long t;
            while (j != 0)
            {
                t = j;
                j = i % j;
                i = t;
            }
            return i;
        }
        private static long getLeastCommonMultiple(long i1, long i2)
        {
            if (i1 == 0 && i2 == 0)
                return 0;
            long lcm = i1 / getGreatestCommonDivisor(i1, i2) * i2;
            return lcm < 0 ? -lcm : lcm;
         }
         ...
         /// <summary>
         /// Returns the nearest rational number approximation to a double-precision floating-point number with a specified precision.
         /// </summary>
         /// <param name="target">Target value of the approximation.</param>
         /// <param name="precision">Minimum precision of the approximation.</param>
         /// <returns>Nearest rational number with, at least, the required precision.</returns>
         /// <exception cref="System.ArgumentException">Can not find a rational number approximation with specified precision.</exception>
         /// <exception cref="System.OverflowException">target is larger than Mathematics.RationalNumber.MaxValue or smaller than Mathematics.RationalNumber.MinValue.</exception>
         /// <remarks>It is important to clarify that the method returns the first rational number found that complies with the specified precision. 
         /// The method is not required to return an exact rational number approximation even if such number exists.
         /// The returned rational number will always be in coprime form.</remarks>
         public static RationalNumber GetNearestRationalNumber(double target, double precision)
         {
             //Continued fraction algorithm: http://en.wikipedia.org/wiki/Continued_fraction
             //Implemented recursively. Problem is figuring out when precision is met without unwinding each solution. Haven't figured out how to do that.
             //Current implementation evaluates a Rational approximation for increasing algorithm depths until precision criteria is met or maximum depth is reached (MAXITERATIONCOUNT)
             //Efficiency is probably improvable but this method will not be used in any performance critical code. No use in optimizing it unless there is a good reason.
             //Current implementation works reasonably well.
             RationalNumber nearestRational = RationalNumber.zero;
             int steps = 0;
             while (Math.Abs(target - (double)nearestRational) > precision)
             {
                 if (steps > MAXITERATIONCOUNT)
                     throw new ArgumentException(Strings.RationalMaximumIterationsExceptionMessage, "precision");
                 nearestRational = getNearestRationalNumber(target, 0, steps++);
             }
             return nearestRational;
         }
        private static RationalNumber getNearestRationalNumber(double number, int currentStep, int maximumSteps)
        {
            long integerPart;
            integerPart = checked((long)number);
            double fractionalPart = number - integerPart;
            while (currentStep < maximumSteps && fractionalPart != 0)
            {
                return integerPart + new RationalNumber(1, getNearestRationalNumber(1 / fractionalPart, ++currentStep, maximumSteps));
            }
            return new RationalNumber(integerPart);
        }     
    }
