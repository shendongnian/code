    class CunningFooRef : FooRef, IEnumerable<FooRef>
    {
        // Implementation...
    }
    FooRef fooRef = new CunningFooRef();
    IEnumerable<FooRef> fooRefEnumerable = Enumerable.Empty<FooRef>();
    Console.WriteLine(fooRef == fooRefEnumerable); // False
    fooRefEnumerable = (IEnumerable<FooRef>) fooRef;
    Console.WriteLine(fooRef == fooRefEnumerable); // True
