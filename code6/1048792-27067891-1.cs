    Console.WriteLine(FooGeneric<string>.SharedData);    // "Fizz"
    FooGeneric<string>.SharedData = "Buzz";
    Console.WriteLine(FooGeneric<string>.SharedData);    // "Buzz"
      
    Console.WriteLine(FooGeneric<int>.SharedData);       // "Buzz"
