    interface IhasGUIDId
    {
        Guid id {get; set;}
    }
    
    class Product : IhasGUIDId
    {
        Guid id {get; set;}
        string name {get; set;}
        int price {get; set;}
    }
    class Customer : IhasGUIDId
    {
        Guid id {get; set;}
        string firstname {get; set;}
        string lastname {get; set;}
    }
