    interface IPerformMethod    
    {
       void SpecialFunction();
    }
    public class Store : IPerformMethod
    {
       public void SpecialFunction()
       {
           Console.WriteLine("Store function");
       }
    }
    public class Checker : IPerformMethod
    {
       public void SpecialFunction()
       {
           Console.WriteLine("Checker function"); 
       }
    }
