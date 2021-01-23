    public interface IHasID
    {
        public Guid id {get; set;}
    }
    
    public class Product: IHasId
    {
        Guid id {get; set;}
        string name {get; set;}
        int price {get; set;}
    }
    public class Customer: IHasId
    {
        Guid id {get; set;}
        string firstname {get; set;}
        string lastname {get; set;}
    }
