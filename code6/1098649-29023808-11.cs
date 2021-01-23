    // Your original lambdas
    Expression<Func<A, IEnumerable<B>>> listGetter = a => a.List;
    Expression<Func<B, string>> propGetter = b => b.SomeString;
    // Stitch them together
    var firstSomeStringGetter = listGetter.Compose(seq => seq.First()).Compose(propGetter);
    // Test out what the body of the expression is
    Console.WriteLine(firstSomeStringGetter.Body.ToString()); // Outputs "a.List.First().SomeString"
    // Test out invoking the expression
    var result = firstSomeStringGetter.Compile()(new A());
    Console.WriteLine(result); // Outputs "Foo"
