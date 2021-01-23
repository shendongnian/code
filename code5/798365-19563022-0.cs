    while(input !=0) 
    {
        FizzBuzz fizzbuzz = new FizzBuzz();
        Console.WriteLine("IsFizz " + fizzbuzz.IsFizz(input)); //Shows if IsFizz is true or false
        Console.WriteLine("IsBuzz " + fizzbuzz.IsBuzz(input)); //Shows if IsBuzz is true or false
        Console.WriteLine("IsFizzBuzz " + fizzbuzz.IsFizzBuzz(input)); //Shows if IsFizzBuzz is true or false
        Console.WriteLine("IsPrime " + fizzbuzz.IsPrime(input)); //Shows if IsPrime is true or false
        Console.WriteLine("Fizz Count total is " + fizzbuzz.TotalFizz()); //Shows the total amount of Fizz counters 
        Console.WriteLine("Buzz Count total is " + fizzbuzz.TotalBuzz()); //Shows the total amount of Buzz counters 
        Console.WriteLine("FizzBuzz Count total is " + fizzbuzz.TotalFizzBuzz()); //Shows the total amount of FizzBuzz counters 
        Console.WriteLine("Prime Count total is " + fizzbuzz.TotalPrime());
        Console.WriteLine("Please enter another number or press 0 to exit");//Shows the total amount of Prime counters 
        inputString = Console.ReadLine();
        // try to convert, if is not succedde, keep the original value (0).
        int.TryParse(inputString, out input);
    }
