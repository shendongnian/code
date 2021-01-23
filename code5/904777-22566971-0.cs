    [ActiveRecord("ClientObjects")]
    public class ClientObject : ActiveRecordBase<ClientObject>
    {
        [PrimaryKey]
        public virtual Guid Id { get; set; }
        [BelongsTo("ClientId", NotNull = true, UniqueKey = "uxClientObjects.Client.Name")]
        public virtual Client Client { get; set; }
        [Property(NotNull = true, Length = 250)]
        public virtual string Type { get; set; }
        [Property(NotNull = true, Length = 70, UniqueKey = "uxClientObjects.Client.Name")]
        public virtual string Name { get; set; }
        [HasMany(typeof(ClientGroupAccess), Inverse = true)]
        public virtual IList<ClientGroupAccess> ObjectAccess { get; set; }
    }
