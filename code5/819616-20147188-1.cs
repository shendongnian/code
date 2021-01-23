    float originalFahrenheit;
    float Kel;
    Console.Write("Enter temperature (Fahrenheit): "); 
    string str = Console.ReadLine();
    
    if (Single.TryParse(str, NumberStyles.Float, out originalFahrenheit))
    {
      //Successful parsing..
    }
