    public interface IOrderProcessor
    {
        ProcessResult Process(OrderOL obj);
    }
    public class OrderProcessor : IOrderProcessor
    {
           public ProcessResult Process(OrderOL obj)
           {
                //TODO:
                // 1- resolve OrderRepositorySQL 
                // 2- create order
                // 3- resolve the other repository
                // 4- create order
                // 5- return the operation result
           }
    }
