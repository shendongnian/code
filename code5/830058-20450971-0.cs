    using System;
    
    namespace ConsoleApplication1
    {
        class Calculation
        {
            public double Radius { get; set; }
            public double Height { get; set; }
    
            public double GetVolume()
            {
               return Math.PI * Radius * Radius * Height;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                double radius;//not used but left for your understanding, you didn't need radius2 in your Calculation class, you could have used the name radius, this is why you need to study variable scope
                double height;//not used but left for your understanding, same reason as radius
                
                Calculation calc = new Calculation();
    
                Console.WriteLine("Enter radius");
                calc.Radius = double.Parse(Console.ReadLine());
                Console.WriteLine(calc.Radius);
                Console.WriteLine("Enter height");
                calc.Height = double.Parse(Console.ReadLine());
                Console.WriteLine(calc.Height);
    
    
                Console.WriteLine(calc.GetVolume());
                Console.ReadLine();
            }
        }
    }
