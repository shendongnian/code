        int ichoice = 0;
        int.TryParse(Console.ReadKey().ToString(), out ichoice );
        do
        {
            if (ichoice == 1)
            {
                Console.WriteLine("Enter Fahrenheit temperature: ");
                fTemp = int.Parse(Console.ReadLine());
                convertC = ConvertCelcius(fTemp);
                Console.WriteLine(fTemp + "Fahrenheit is " + convertC + "Celsius");
                Console.WriteLine("Welcome to the temperature conversion application");
                     Console.WriteLine("_________________________________________________");
                int.TryParse(Console.ReadKey().ToString(), out ichoice );
