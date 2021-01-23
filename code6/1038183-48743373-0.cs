    // Get the new context
    HttpContext context = HttpContext.Current;
    Parallel.ForEach(items, item =>
        {
            DoSomething(context);
        }
    );
    private static void DoSomething(HttpContext context) {
     HttpContext.Current = context;
    }
