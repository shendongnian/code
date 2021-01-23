        static void Main(string[] args)
        {
            double propertyValue = 0.0;
            double assessTax = 0.0;
            double propertyTax = 0.0;
            propertyValue = GetValue();
            assessTax = GetAssessTax(propertyValue);
            propertyTax = GetTax(assessTax);
            ShowOutput(propertyValue, assessTax, propertyTax);
            Console.ReadKey(true);
        }
        static void ShowOutput(double propertyValue, double assessTax, double propertyTax)
        {
            Console.WriteLine("Your Entered Property Value was {0, 10:C}", propertyValue);
            Console.WriteLine("Your Assessment Value is {0, 10:C}", assessTax);
            Console.WriteLine("Your Property Tax is {0, 10:C}", propertyTax);
        }
        static double GetValue()
        {
            double propertyValue;
            Console.WriteLine("Please Enter Property Value");
            while (!double.TryParse(Console.ReadLine(), out propertyValue))
                Console.WriteLine("Error, Please enter a valid number");
            return propertyValue;
        }
        static double GetAssessTax(double propertyValue)
        {
            return  propertyValue * 0.60;
        }
        static double GetTax(double assessTax)
        {
            return (assessTax / 100) * 0.64;
        }
