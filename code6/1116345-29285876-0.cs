    var data = this.TestData()
        .GroupBy(gb => new { gb.GroupProperty, gb.RandomProperty })
        .Select(s => new Foo(
             s.Key.GroupProperty, 
             s.Key.RandomProperty, 
             s.Select(b => new Bar(b.SomeProperty, b.someOtherProperty)).ToList())
            ));
