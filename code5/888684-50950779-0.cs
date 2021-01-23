    [Table(Name = "dbo.mytable")]
    [JsonObject(MemberSerialization.OptOut)]
    public sealed class mytable : DataEntity
    {
        ...
    }
