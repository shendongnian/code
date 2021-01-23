     public void PerformSomeCalculations(ICalculator calculator)
     {
         calculator.Sum(5, 5);
         // Assuming interface defines a property `Result`.
         Console.WriteLine(calculator.Result); 
     }
