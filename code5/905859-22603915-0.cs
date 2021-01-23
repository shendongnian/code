    class Program
    {
        enum ZodiacSign
        {
            Aries, // March 21 - April 20
            Taurus, // April 21 - May 21
            Gemini, // May 22 - June 21
            Cancer, // June 22 - July 22
            Leo, // July 23 -August 21
            Virgo, // August 22 - September 23
            Libra, // September 24 - October 23
            Scorpio, // October 24 - November 22
            Sagittarius, // November 23 - December 22
            Capricorn, // December 23 - January 20
            Aquarius, // January 21 - February 19
            Pisces // February 20- March 20
        }
    
        static ZodiacSign BirthdayToZodiacSign(DateTime birthday)
        {
            var periodEndList = new[] {
                new { PeriodEnd = new DateTime(birthday.Year, 1, 20), ZodiacSign = ZodiacSign.Capricorn },
                new { PeriodEnd = new DateTime(birthday.Year, 2, 19), ZodiacSign = ZodiacSign.Aquarius },
                new { PeriodEnd = new DateTime(birthday.Year, 3, 20), ZodiacSign = ZodiacSign.Pisces },
                new { PeriodEnd = new DateTime(birthday.Year, 4, 20), ZodiacSign = ZodiacSign.Aries },
                new { PeriodEnd = new DateTime(birthday.Year, 5, 21), ZodiacSign = ZodiacSign.Taurus },
                new { PeriodEnd = new DateTime(birthday.Year, 6, 21), ZodiacSign = ZodiacSign.Gemini },
                new { PeriodEnd = new DateTime(birthday.Year, 7, 22), ZodiacSign = ZodiacSign.Cancer },
                new { PeriodEnd = new DateTime(birthday.Year, 8, 21), ZodiacSign = ZodiacSign.Leo },
                new { PeriodEnd = new DateTime(birthday.Year, 9, 23), ZodiacSign = ZodiacSign.Virgo },
                new { PeriodEnd = new DateTime(birthday.Year, 10, 23), ZodiacSign = ZodiacSign.Libra },
                new { PeriodEnd = new DateTime(birthday.Year, 11, 22), ZodiacSign = ZodiacSign.Scorpio },
                new { PeriodEnd = new DateTime(birthday.Year, 12, 22), ZodiacSign = ZodiacSign.Sagittarius }
            };
    
            foreach (var periodEnd in periodEndList)
                if (birthday <= periodEnd.PeriodEnd)
                    return periodEnd.ZodiacSign;
            return ZodiacSign.Capricorn;
        }
    
        static string GenerateCompatibilityString(DateTime birthday1, DateTime birthday2)
        {
            return string.Format("Compatibility of {0} with {1}", BirthdayToZodiacSign(birthday1), BirthdayToZodiacSign(birthday2));
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(GenerateCompatibilityString(new DateTime(2014, 1, 1), new DateTime(2014, 6, 7)));
        }
    }
