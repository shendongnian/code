    class Program
    {
        public static void Main(string[] args)
        {
            double radius = 0.00;
            double height = 0.00;
            double volume = 0.00;
            Calculator calObject = new Calculator();
            System.Console.WriteLine("Enter radius");
            radius = double.Parse(System.Console.ReadLine());
            System.Console.WriteLine(radius);
            System.Console.WriteLine("Enter height");
            height = double.Parse(System.Console.ReadLine());
            System.Console.WriteLine(height);
            volume = calObject.FindVolumne(radius, height);
            System.Console.WriteLine(volume);
            Console.ReadLine();
        }
     }
    public class Calculator
    {
        public double FindVolumne(double radius, double height)
        {
            double volume = 0.00;
            volume = Math.PI * radius * radius * height;
            return volume;
        }
    }
