    class Program
    {
        private static void Main(string[] args)
        {
            MonthlySalaryCalculator obj = new MonthlySalaryCalculator();
            obj.Calculate();
            Console.Read();
        }
    }
    public class DailySalaryCalculator
    {
        public void Calculate()
        {
            Console.WriteLine("DailySalaryCalculator");
        }
    }
    public class WeeklySalaryCalculator : DailySalaryCalculator
    {
        public void Calculate()
        {
            Console.WriteLine("WeeklySalaryCalculator");
        }
    }
    public class MonthlySalaryCalculator : WeeklySalaryCalculator
    {
        public void Calculate()
        {
            (this.MemberwiseClone() as DailySalaryCalculator).Calculate();
        }
    }
