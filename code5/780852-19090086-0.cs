    public class Magazine:INamedEntity,ITypedEntity
    {
    public int Id {get;set;}
    [MaxLength(250)]
    public string Name {get;set;}
    public TypedEntity Type { get; set; }
    }
