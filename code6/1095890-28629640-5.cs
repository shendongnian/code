    class Program
    {
        // We're declaring this function static so you can use it without an instance of the class
        static decimal GetUserInput(string inputQuery, decimal min, decimal max)
        {
          Console.Write(inputQuery);
          decimal val;
          while(true)
          {
            if(!decimal.TryParse(Console.ReadLine(), out val))
              Console.Write("Please enter a valid decimal value: $");
            else if(val < min || val > max)
              Console.Write("Please enter an amount between " + min + " and " + max + ": $");
            else // the value is a decimal AND it's correct
              break;
          } 
          return val;
        }
    
        static void Main()
        {
          // Your original code went here, but see how my function is *outside* function Main()
          // You use my function (GetUserInput) here:
          var startingBalance = GetUserInput("Starting Balance: $", 1, 100000);
          var endingBalance = GetUserInput("Ending Balance: $", 1, 100000);
    
          // Then you can do:
          Console.WriteLine("Starting balance was: " + startingBalance.ToString("n"));
        }
    }
