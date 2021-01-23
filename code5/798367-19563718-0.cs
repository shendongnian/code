    public static void Main()
    {
    Console.WriteLine("Please enter a number ");
    string inputString;
    inputString = Console.ReadLine();
    int input;
    input = int.Parse(inputString);    
    while(input !=0)
    {
    FizzBuzz fizzbuzz = new FizzBuzz();
    Console.WriteLine("IsFizz {0}", fizzbuzz.IsFizz(input)); 
    Console.WriteLine("IsBuzz {0}", fizzbuzz.IsBuzz(input)); 
    Console.WriteLine("IsFizzBuzz {0}", fizzbuzz.IsFizzBuzz(input));
    Console.WriteLine("IsPrime {0}", fizzbuzz.IsPrime(input)); 
    Console.WriteLine("Fizz Count total is {0}", fizzbuzz.TotalFizz());
    Console.WriteLine("Buzz Count total is {0}", fizzbuzz.TotalBuzz());
    Console.WriteLine("FizzBuzz Count total is {0}", fizzbuzz.TotalFizzBuzz()); 
    Console.WriteLine("Prime Count total is {0}", fizzbuzz.TotalPrime());
    Console.WriteLine("Please enter another number or press 0 to exit");
    inputString = Console.ReadLine();
    input = int.Parse(inputString);  
    }
    }
