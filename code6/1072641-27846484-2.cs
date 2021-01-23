    interface IAggregateRoot<TKey> 
    {
        TKey Key { get; }
    }
    
    //entity which is aggregate root
    class Car : IAggregateRoot<int>
    {
       int Key { get; }
       Ienumerable<Door> Doors { get; }
    }
    
    //other entity, not aggregate root
    class Door 
    {
       string Colour { get; set; }
    }
    
    //generic interface with IAggregateRoot constraint
    interface IRepository<TAggregateRoot, TKey> where TAggregateRoot : IAggregateRoot
    {
       TAggregateRoot Get(TKey key)
       //other methods
    }
