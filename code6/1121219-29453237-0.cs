    Random rnd = new Random();
    int num1 = rnd.Next(1, 3);
    int num2;
    
    Console.WriteLine("Guess my number");
    while(true)
    {  
       //NOTE, if the user entered characters other than number, the program
       //will throw an exception, you should check user input before making the parsing
       num2 = int.Parse(Console.ReadLine());
       if (num2 == num1)
       {
       Console.WriteLine("Very Good!");
       break;
       }
       else
        Console.WriteLine("Guess again");
    }
    Console.ReadLine();
