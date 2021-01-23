    // Simplified Foo to prevent a lot of typing.
    public class Foo
    {
        public int bar1 { get; set; }
        public int bar2 { get; set; }
        public double foobar1 { get; set; }
    }
    var myFooList = new List<Foo>
    {
        new Foo() { bar1 = 1, bar2 = 2, foobar1 = 20.0 },
        new Foo() { bar1 = 5, bar2 = 8, foobar1 = 42.0 },
        new Foo() { bar1 = 9, bar2 = 3, foobar1 = -10.0 },
    };
    var myFooSum = myFooList.Aggregate(new Foo(), (curSum, foo) =>
    {
        curSum.bar1 += foo.bar1;
        curSum.bar2 += foo.bar2;
        curSum.foobar1 += foo.foobar1;
        return curSum;
    });
    Console.WriteLine("FooSum: bar1 = {0}, bar2 = {1}, bar3 = {2}", myFooSum.bar1, myFooSum.bar2, myFooSum.foobar1);
