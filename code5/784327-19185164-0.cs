    class Program
    {
        static void Main(string[] args)
        {
            double value, peso, euro;
            Console.Write("Enter the value: ");
            value = double.Parse(Console.ReadLine());
            Console.WriteLine("The value is = {0} peso", peso = ValueToPeso(value));
            Console.WriteLine("The value is = {0} euro", (euro = ValueToEuro(value)).ToString("f2"));
        }
        // convert value to Peso
        public static double ValueToPeso(double value)
        {
            return value * 17;
        }
        // convert value to Euro 
        public static double ValueToEuro(double value)
        {
            return value / 17;
        }
    }
