    var list = new ABList<dynamic>(); // issue here; see comment below
    list.Add(new A());
    list.Add(new B());
    list.First().Foo();
    list.Last().Bar();
