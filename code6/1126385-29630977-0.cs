    public interface IStrategy
    {
        int getValue();
    }
    public class Context
    {
        private readonly IStrategy strategy;
        public Context(IStrategy strategy)
        {
           this.strategy = strategy;
        }
        public int common_calculation()
        {
            return 5 * strategy.getValue();
        }
    }
    public class FiveStrategy : IStrategy
    {
         public int getValue()
         {
             return 5;
         }
    }
    public class TenStrategy : IStrategy
    {
        public int getValue()
        {
            return 10;
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            var context5 = new Context(new FiveStrategy());
            Console.WriteLine(context5.common_calculation());
            var context10 = new Context(new TenStrategy());
            Console.WriteLine(context10.common_calculation());
            Console.ReadLine();
        }
    }
