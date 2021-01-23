    // ...
    var print_test = context.Get("print_test");
    if (print_test.IsFunction)
    {
      print_test.AsFunction()(null);
    }
    else
    {
      Console.Write("print_test not a lua function!");
    }
    // ...
