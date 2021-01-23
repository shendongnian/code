    string[] someArray = { "arrays", "are", "amazing" };
    Console.WriteLine(someArray.Length); // Prints 3
    Console.WriteLine(someArray[2]); // Prints "amazing"
    Console.WriteLine(someArray[someArray.Length]); // Blows up because there is no
                                                    // element of the array with
                                                    // index of 3.
    Console.WriteLine(someArray[someArray.Length - 1]); // Prints "amazing"
