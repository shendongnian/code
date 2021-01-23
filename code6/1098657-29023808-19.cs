    // Test out what the body of the expression is
    Console.WriteLine(firstSomeStringGetter.Body.ToString()); // Outputs "a.List.First().SomeString"
    // Test out invoking the expression
    var result = firstSomeStringGetter.Compile()(new A());
    Console.WriteLine(result); // Outputs "Foo"
