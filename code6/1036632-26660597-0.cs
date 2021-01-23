    public class Program
    {
        public static void Main()
        {
            double[] input = new double[12];
            for (int i = 0; i < 12; i++)
            {
                Console.Write(" Type in {0} number:", i);
                input[i] = [Convert.ToDouble(Console.ReadLine())];
            } 
    
            Console.WriteLine("The highest number is {0}", input.Max(element => Math.Abs(element)));
    
            Console.ReadKey();
        }
    }
