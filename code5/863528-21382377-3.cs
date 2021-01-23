    Expression<Func<Foo, bool>> x = foo => foo.IsAlive,
        y = foo => !foo.IsAlive;
    var a = BooleanComplexifier.Process(x); // foo => foo.IsAlive == true
    var b = BooleanComplexifier.Process(y); // foo => foo.IsAlive != true
    //...
    class Foo
    {
        public bool IsAlive { get;set; }
    }
