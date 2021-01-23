    public class Foo
    {
        public string Bar { get; set; }
        public bool Flag { get; set; }
    }
    var bars = SelectData<Foo, string>("Bar");
    var foo = FirstOrDefaultData<Foo>("Bar",
                                      "Flag",
                                      (p, c) => Expression.GreaterThan(p, c));
