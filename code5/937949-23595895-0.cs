    public struct Fraction : IEquatable<Fraction>
    {
        long _numerator;
        public long Numerator
        {
            get { return _numerator; }
            private set { _numerator = value; }
        }
    
        long _denominator;
        public long Denominator
        {
            get { return _denominator == 0 ? 1 : _denominator; }
            private set
            {
                if (value == 0)
                    throw new InvalidOperationException("Denominator cannot be assigned a 0 Value.");
    
                _denominator = value;
            }
        }
    
        public Fraction(long value)
        {
            _numerator = value;
            _denominator = 1;
            Reduce();
        }
        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new InvalidOperationException("Denominator cannot be assigned a 0 Value.");
    
            _numerator = numerator;
            _denominator = denominator;
            Reduce();
        }
    
    
        private void Reduce()
        {
            try
            {
                if (Numerator == 0)
                {
                    Denominator = 1;
                    return;
                }
    
                long iGCD = GCD(Numerator, Denominator);
                Numerator /= iGCD;
                Denominator /= iGCD;
    
                if (Denominator < 0)
                {
                    Numerator *= -1;
                    Denominator *= -1;
                }
            }
            catch (Exception exp)
            {
                throw new InvalidOperationException("Cannot reduce Fraction: " + exp.Message);
            }
        }
    
        public bool Equals(Fraction other)
        {
            if (other == null)
                return false;
    
            return (Numerator == other.Numerator && Denominator == other.Denominator);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Fraction))
                return false;
    
            return Equals((Fraction)obj);
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32((Numerator ^ Denominator) & 0xFFFFFFFF);
        }
        public override string ToString()
        {
            if (this.Denominator == 1)
                return this.Numerator.ToString();
    
            var sb = new System.Text.StringBuilder();
            sb.Append(this.Numerator);
            sb.Append('/');
            sb.Append(this.Denominator);
    
            return sb.ToString();
        }
    
        public static Fraction Parse(string strValue)
        {
            int i = strValue.IndexOf('/');
            if (i == -1)
                return DecimalToFraction(Convert.ToDecimal(strValue));
    
            long iNumerator = Convert.ToInt64(strValue.Substring(0, i));
            long iDenominator = Convert.ToInt64(strValue.Substring(i + 1));
            return new Fraction(iNumerator, iDenominator);
        }
        public static bool TryParse(string strValue, out Fraction fraction)
        {
            if (!string.IsNullOrWhiteSpace(strValue))
            {
                try
                {
                    int i = strValue.IndexOf('/');
                    if (i == -1)
                    {
                        decimal dValue;
                        if (decimal.TryParse(strValue, out dValue))
                        {
                            fraction = DecimalToFraction(dValue);
                            return true;
                        }
                    }
                    else
                    {
                        long iNumerator, iDenominator;
                        if (long.TryParse(strValue.Substring(0, i), out iNumerator) && long.TryParse(strValue.Substring(i + 1), out iDenominator))
                        {
                            fraction = new Fraction(iNumerator, iDenominator);
                            return true;
                        }
                    }
                }
                catch { }
            }
    
            fraction = new Fraction();
            return false;
        }
    
        private static Fraction DoubleToFraction(double dValue)
        {
            char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
    
            try
            {
                checked
                {
                    Fraction frac;
                    if (dValue % 1 == 0)	// if whole number
                    {
                        frac = new Fraction((long)dValue);
                    }
                    else
                    {
                        double dTemp = dValue;
                        long iMultiple = 1;
                        string strTemp = dValue.ToString();
                        while (strTemp.IndexOf("E") > 0)	// if in the form like 12E-9
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            strTemp = dTemp.ToString();
                        }
                        int i = 0;
                        while (strTemp[i] != separator)
                            i++;
                        int iDigitsAfterDecimal = strTemp.Length - i - 1;
                        while (iDigitsAfterDecimal > 0)
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            iDigitsAfterDecimal--;
                        }
                        frac = new Fraction((int)Math.Round(dTemp), iMultiple);
                    }
                    return frac;
                }
            }
            catch (OverflowException e)
            {
                throw new InvalidCastException("Conversion to Fraction in no possible due to overflow.", e);
            }
            catch (Exception e)
            {
                throw new InvalidCastException("Conversion to Fraction in not possible.", e);
            }
        }
        private static Fraction DecimalToFraction(decimal dValue)
        {
            char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
    
            try
            {
                checked
                {
                    Fraction frac;
                    if (dValue % 1 == 0)	// if whole number
                    {
                        frac = new Fraction((long)dValue);
                    }
                    else
                    {
                        decimal dTemp = dValue;
                        long iMultiple = 1;
                        string strTemp = dValue.ToString();
                        while (strTemp.IndexOf("E") > 0)	// if in the form like 12E-9
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            strTemp = dTemp.ToString();
                        }
                        int i = 0;
                        while (strTemp[i] != separator)
                            i++;
                        int iDigitsAfterDecimal = strTemp.Length - i - 1;
                        while (iDigitsAfterDecimal > 0)
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            iDigitsAfterDecimal--;
                        }
                        frac = new Fraction((int)Math.Round(dTemp), iMultiple);
                    }
                    return frac;
                }
            }
            catch (OverflowException e)
            {
                throw new InvalidCastException("Conversion to Fraction in no possible due to overflow.", e);
            }
            catch (Exception e)
            {
                throw new InvalidCastException("Conversion to Fraction in not possible.", e);
            }
        }
    
        private static Fraction Inverse(Fraction frac1)
        {
            if (frac1.Numerator == 0)
                throw new InvalidOperationException("Operation not possible (Denominator cannot be assigned a ZERO Value)");
    
            long iNumerator = frac1.Denominator;
            long iDenominator = frac1.Numerator;
            return new Fraction(iNumerator, iDenominator);
        }
        private static Fraction Negate(Fraction frac1)
        {
            long iNumerator = -frac1.Numerator;
            long iDenominator = frac1.Denominator;
            return new Fraction(iNumerator, iDenominator);
    
        }
        private static Fraction Add(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    long iNumerator = frac1.Numerator * frac2.Denominator + frac2.Numerator * frac1.Denominator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return new Fraction(iNumerator, iDenominator);
                }
            }
            catch (OverflowException e)
            {
                throw new OverflowException("Overflow occurred while performing arithemetic operation on Fraction.", e);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while performing arithemetic operation on Fraction.", e);
            }
        }
        private static Fraction Multiply(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    long iNumerator = frac1.Numerator * frac2.Numerator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return new Fraction(iNumerator, iDenominator);
                }
            }
            catch (OverflowException e)
            {
                throw new OverflowException("Overflow occurred while performing arithemetic operation on Fraction.", e);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while performing arithemetic operation on Fraction.", e);
            }
        }
    
        private static long GCD(long iNo1, long iNo2)
        {
            if (iNo1 < 0) iNo1 = -iNo1;
            if (iNo2 < 0) iNo2 = -iNo2;
    
            do
            {
                if (iNo1 < iNo2)
                {
                    long tmp = iNo1;
                    iNo1 = iNo2;
                    iNo2 = tmp;
                }
                iNo1 = iNo1 % iNo2;
            }
            while (iNo1 != 0);
    
            return iNo2;
        }
    
        public static Fraction operator -(Fraction frac1) { return (Negate(frac1)); }
        public static Fraction operator +(Fraction frac1, Fraction frac2) { return (Add(frac1, frac2)); }
        public static Fraction operator -(Fraction frac1, Fraction frac2) { return (Add(frac1, -frac2)); }
        public static Fraction operator *(Fraction frac1, Fraction frac2) { return (Multiply(frac1, frac2)); }
        public static Fraction operator /(Fraction frac1, Fraction frac2) { return (Multiply(frac1, Inverse(frac2))); }
    
        public static bool operator ==(Fraction frac1, Fraction frac2) { return frac1.Equals(frac2); }
        public static bool operator !=(Fraction frac1, Fraction frac2) { return (!frac1.Equals(frac2)); }
        public static bool operator <(Fraction frac1, Fraction frac2) { return frac1.Numerator * frac2.Denominator < frac2.Numerator * frac1.Denominator; }
        public static bool operator >(Fraction frac1, Fraction frac2) { return frac1.Numerator * frac2.Denominator > frac2.Numerator * frac1.Denominator; }
        public static bool operator <=(Fraction frac1, Fraction frac2) { return frac1.Numerator * frac2.Denominator <= frac2.Numerator * frac1.Denominator; }
        public static bool operator >=(Fraction frac1, Fraction frac2) { return frac1.Numerator * frac2.Denominator >= frac2.Numerator * frac1.Denominator; }
    
        public static implicit operator Fraction(long value) { return new Fraction(value); }
        public static implicit operator Fraction(double value) { return DoubleToFraction(value); }
        public static implicit operator Fraction(decimal value) { return DecimalToFraction(value); }
    
        public static explicit operator double(Fraction frac)
        {
            return ((double)frac.Numerator / frac.Denominator);
        }
        public static explicit operator decimal(Fraction frac)
        {
            return ((decimal)frac.Numerator / (decimal)frac.Denominator);
        }
    }
