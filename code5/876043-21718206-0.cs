     namespace YourNameSpace
    {
     static void Main(string[] args)
     {
    double fTemp;
    double cTemp;
    double convertC;
    double convertF;
    int iChoice;
    Console.WriteLine("Welcome to the temperature conversion application");
    Console.WriteLine("_________________________________________________");
    Console.WriteLine("1. Fahrenheit to Celsius");
    Console.WriteLine("2. Celsius to Fahrenheit");
    Console.Write("Enter choice(0 to exit): ");
    iChoice = Console.Read();
    do{
        switch(iChoice)
        {
           case 1:
              Console.WriteLine("Enter Fahrenheit temperature: ");
              fTemp = int.Parse(Console.ReadLine());
              convertC = ConvertCelcius(fTemp);
              Console.WriteLine(fTemp + "Fahrenheit is " + convertC + "Celsius");
          case 2:
              Console.WriteLine("Enter Celsius temperature: ");
              cTemp = int.Parse(Console.ReadLine());
              convertF = ConvertFahrenheit(cTemp);
              Console.WriteLine(cTemp + "Celsius is " + convertF + "Fahrenheit");
                  
       }
       Console.WriteLine("Welcome to the temperature conversion application");
       Console.WriteLine("_________________________________________________");
       Console.WriteLine("1. Fahrenheit to Celsius");
       Console.WriteLine("2. Celsius to Fahrenheit");
       Console.Write("Enter choice(0 to exit): ");
       iChoice = Console.Read();
    
       }while(iChoice != 0);
    
     }
     static double ConvertCelcius(double c){
                double f;
                return f= 9.0 / 5.0 * c + 32;
        }
        static double ConvertFahrenheit(double f) {
             double c;
                 return c = 5.0 / 9.0 * (f - 32);
        }
    }
