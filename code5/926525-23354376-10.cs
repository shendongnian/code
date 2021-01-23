    public interface IThing:IEntity{}
    public interface IThing_Property: IThing, IEntityProperty
    {
        int SimpleProperty{get;set;}
    }
    public interface IThing_ComplexProperty: IThing, IEntityObject{}
    public interface IThing_ComplexProperty<T> : IEntity_ComplexProperty where T:class, IEntity,new()
    {
       T SomeProperty{get;set;}
    }
    public interface IThing_CollectionProperty: IThing, IEntityCollection{}
    public interface IThing_CollectionProperty<T> :IEntity_CollectionProperty where T:class, IEntity,new()
    {
       IEnumerable<T> SomeCollectionProperty{get;set;}
    }
