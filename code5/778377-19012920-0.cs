        static void Main(string[] args)
        {
            Fraction n = new Fraction(2, 4);
            Fraction z = new Fraction(3, 12);
            Fraction sum = Add(z, n);
            int x = sum.Numerator;
            int y = sum.Denominator;
            Console.WriteLine("{0}/{1}", x, y);
            Console.ReadKey(true);
        }
        public static Fraction Add(Fraction fraction2, Fraction fraction8)
        {
            int lcd = GetLCD(fraction8, fraction2);
            if (fraction2.Denominator < lcd)
            {
                int multiplier = lcd / fraction2.Denominator;
                fraction2.Numerator = multiplier * (fraction2.Numerator);
                fraction2.Denominator = multiplier * (fraction2.Denominator);
            }
            else
            {
                int multiplier = lcd / fraction8.Denominator;
                fraction8.Numerator = multiplier * (fraction8.Numerator);
                fraction8.Denominator = multiplier * (fraction8.Denominator);
            }
            Fraction Fraction3 = new Fraction(fraction2.Numerator + fraction8.Numerator, lcd);
            return Fraction3;
        }
        public static int GetLCD(Fraction b, Fraction c)
        {
            int i = b.Denominator;
            int j = c.Denominator;
            int greater = 0;
            int lesser = 0;
            if (i > j)
            {
                greater = i; lesser = j;
            }
            else if (i < j)
            {
                greater = j; lesser = i;
            }
            else
            {
                return i;
            }
            for (int iterator = 1; iterator <= lesser; iterator++)
            {
                if ((greater * iterator) % lesser == 0)
                {
                    return iterator * greater;
                }
            }
            return 0;
        }
        internal class Fraction
        {
            public Fraction(int numerator, int denominator)
            {
                Numerator = numerator;
                Denominator = denominator;
            }
            public int Numerator { get; set; }
            public int Denominator { get; set; }
        }
