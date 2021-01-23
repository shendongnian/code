    static void Overloaded(Action a, string param) { }
    static void Overloaded(Expression<Action> e) { }
    static void CallToAction(Action a) { }
    static void CallToExprAc(Expression<Action> a) { }
    static void Main(string[] args)
    {
        // Works
        CallToAction(() => Overloaded(() => { int i = 5; }, "hi"));
        // Doesn't work - using the Expression overload
        CallToAction(() => Overloaded(() => { int i = 5; }));
        // Doesn't work - wrapped in an outer Expression
        CallToExprAc(() => Overloaded(() => { int i = 5; }, "hi"));
    }
