    public class Program
    {
        static void Main()
        {
            int sum = 0;
    
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter Integer {0} now.", (i + 1));
                
                int value; 
                while (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("This is not a valid integer. Please enter a valid integer {0} now:", i + 1);
                }
    
                sum += value;
            }
    
            Console.WriteLine(sum);        
        }
    }
