    interface ITypedEntity<TType> where TType : TypedEntity
    {
        TType Type { get; set; }
    }
    class Magazine : ITypedEntity<MagazineType>
    {
        // ...
    }
