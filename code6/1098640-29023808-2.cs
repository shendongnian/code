    // Your original lambdas
    Expression<Func<A, IEnumerable<B>>> listGetter = a => a.List;
    Expression<Func<B, string>> propGetter = b => b.SomeString;
    // Stitch them together
    var firstBGetter = listGetter.Compose(seq => seq.First()).Compose(propGetter);
    // Test out what the body of the expression is
    Console.WriteLine(firstBGetter.Body.ToString()); // Outputs "a.Bs.First().SomeString"
    // Test out invoking the expression
    var result = firstBGetter.Compile()(new A());
    Console.WriteLine(result); // Outputs "Foo"
