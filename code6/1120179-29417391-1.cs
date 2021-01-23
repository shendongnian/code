    public class Program
    {
        static void Main()
        {
            int sum = 0, value = 0;
    
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Please enter Integer {0} now.", i);
    
                while (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("This is not a valid integer. Please enter a valid integer {0} now:", i);
                }
    
                sum += value;
            }
    
            Console.WriteLine(sum);
            
        }
    }
