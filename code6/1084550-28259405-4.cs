    static IEnumerator SomethingEnumerable()
    {
        using (var disposable = new SomeDisposable())
        {
            try
            {
                Console.WriteLine("Step 1");
                yield return null;
                Console.WriteLine("Step 2");
                yield return null;
                Console.WriteLine("Step 3");
                yield return null;
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
    // ...
    var something = SomethingEnumerable();
    something.MoveNext(); // prints "Step 1"
    var disposable = (IDisposable)something;
    disposable.Dispose(); // prints "Finally", "SomeDisposable.Dispose"
