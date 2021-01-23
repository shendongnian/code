            string DutchDecimal = "1,5";
            string EnglishDecimal = "1.5";
            decimal a;
            decimal b;
            Console.WriteLine(decimal.TryParse(DutchDecimal, out a));
            Console.WriteLine(a);
            Console.WriteLine(decimal.TryParse(EnglishDecimal, out b));
            Console.WriteLine(b);
            Console.Read();
