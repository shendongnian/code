    static void Main()
    {
         Console.WriteLine("Enter a Number : ");
    
         string input = Console.ReadLine();
         int num, sum = 0;
    
         if (int.TryParse(input, out num))
         {
             for (; num > 0; num = num / 10)
             {
                 sum = sum + num % 10;
             }
    
             Console.WriteLine("The sum of the digits in the number: {0} is {1}", input, sum);
         }
         else { Console.WriteLine("Invalid number format."); }
    
         Console.ReadKey();
     }
