    public class Example
    {
        public static int Calculate(Expression<Func<int>> expr)
        {
           return expr.Compile()();
        }
    }
    void Main()
    {
        var mult = Example.Calculate(() => 4 * 3); //returns 12
        var add = Example.Calculate(() => 4 + 3);  // returns 7
    }
