    public class Calculator
    {
        //public Decimal displayValue;
        public Decimal currentValue;
        public void Add(Decimal displayValue)
        {
            currentValue+=displayValue;
        }
        ...
        public void Clear()
        {
            currentValue=0;
            //displayValue=0;
        }
        public decimal CurrentValue
        {
            get { return currentValue; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc=new Calculator();
            calc.Add(1000m);
            calc.Divide(25m);
            calc.Subtract(8m);
            Console.WriteLine(calc.CurrentValue);
            // (1000/25)-8 = 32
        }
    }
