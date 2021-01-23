    public class Bar
    {
        public int baz { get; set; }
        public double booz { get; set; }
        public string nonNumeric { get; set; }
    }
    static double SumNumericalProperties(object obj)
    {
        if (obj == null)
            return 0;
        if (obj is int)
            return (int)obj;
        if (obj is double)
            return (double)obj;
        // etc for other numeric types.
            
        var sum = 0.0;
        foreach (var prop in obj.GetType().GetProperties())
        {
            if (typeof(int).IsAssignableFrom(prop.PropertyType))
                sum += (int)prop.GetValue(obj);
            else if (typeof(double).IsAssignableFrom(prop.PropertyType))
                sum += (double)prop.GetValue(obj);
            // etc for other numeric types.
        }
        return sum;
    }
    var myObjectList = new List<object>
    {
        new Foo() { bar1 = 1, bar2 = 2, foobar1 = 20.0 },
        new Bar() { baz = 10, booz = 100.0 },
        24,
        33.3333,
        new Foo() { bar1 = 5, bar2 = 8, foobar1 = 42.0 },
        new Foo() { bar1 = 9, bar2 = 3, foobar1 = -10.0 },
    };
    var myFooSum = myObjectList.Aggregate(0.0, (curSum, obj) => curSum + SumNumericalProperties(obj));
    Console.WriteLine("Sum = {0}", myFooSum);
