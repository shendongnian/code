    class Program
    {
       static void Main(string[] args)
       {
           var numbers = GetNumbers();
           CountNumbers(numbers);
    	   
           Console.ReadLine();
       }
    
       private static void CountNumbers(List<int> numbers)
       {
           Console.WriteLine("There are {0} numbers the list", numbers.Count);
       }
    
       private static List<int> GetNumbers()
       {
           var random = new Random();
    	   var numbers = new List<int>();
    	   
           for (int i = 0; i < 333; i++)
           {
               numbers.Add(random.Next(1, 101));             
           }
    	   
    	   numbers = numbers.Distinct().ToList();
           Console.WriteLine("After distinct there are {0} numbers in the list",numbers.Count);
    	   
           return numbers;
       }
    }
