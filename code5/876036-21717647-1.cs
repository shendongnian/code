    double fTemp;
    double cTemp;
    double convertC;
    double convertF;
    Console.WriteLine("Welcome to the temperature conversion application");
    Console.WriteLine("_________________________________________________");
    Console.WriteLine("1. Fahrenheit to Celsius");
    Console.WriteLine("2. Celsius to Fahrenheit");
    Console.WriteLine("3. Exit");
    int ichoice = 0;
    GetChoice(ref ichoice);
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
           GetChoice(ref ichoice);
      }
      if (ichoice == 2)
      {
           Console.WriteLine("Enter Celsius temperature: ");
           cTemp = int.Parse(Console.ReadLine());
           Console.WriteLine(cTemp + "Celsius is " + cTemp  + "Fahrenheit");
           Console.WriteLine("Welcome to the temperature conversion application");
           Console.WriteLine("____________________________________________________");
           GetChoice(ref ichoice);   
      }
      if (ichoice == 3)
      {
           Console.WriteLine("Thank you for using the temperature conversion application. Please come again.");
      }
      else
      {
           Console.WriteLine("Invalid choice. Please choose again!");
      }
    }
    while (ichoice < 3);
          
    }
    static double ConvertCelcius(double c)
    {
        double f;
        return f = 9.0 / 5.0 * c + 32;
    }
    static double ConvertFahrenheit(double f)
    {
        double c;
        return c = 5.0 / 9.0 * (f - 32);
    }
