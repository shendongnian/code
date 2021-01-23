    public interface IOperation
    {
      int Sum(int a, int b);
    }
    private interface IInventoryQuery
    {
      int GetInventoryCount();
    }
    // Dependency #1
    public class DefaultOperation : IOperation
    {
      public int Sum(int a, int b)
      {
        return (a + b);
      }
    }
    // Dependency #2
    private class DefaultInventoryQuery : IInventoryQuery
    {
      public int GetInventoryCount()
      {
        return 1;
      }
    }
    // Dependent class
    public class ReceivingCalculator
    {
      private readonly IOperation _operation;
      private readonly IInventoryQuery _inventoryQuery;
      
      public ReceivingCalculator(IOperation operation, IInventoryQuery inventoryQuery)
      {
        if (operation == null) throw new ArgumentNullException("operation");
        if (inventoryQuery == null) throw new ArgumentNullException("inventoryQuery");
        _operation = operation;
        _inventoryQuery = inventoryQuery;
      }
      
      public int UpdateInventoryOnHand(int receivedCount)
      {
        var onHand = _inventoryQuery.GetInventoryCount();
        var returnValue = _operation.Sum(onHand, receivedCount);
        
        return returnValue;
      }
    }
    // Application
    static void Main()
    {
      var operation = new DefaultOperation();
      var inventoryQuery = new DefaultInventoryQuery();
      var calculator = new ReceivingCalculator(operation, inventoryQuery);
      
      var receivedCount = 8;
      var newOnHandCount = calculator.UpdateInventoryOnHand(receivedCount);
      
      Console.WriteLine(receivedCount.ToString());
      Console.ReadLine();
    }
        
