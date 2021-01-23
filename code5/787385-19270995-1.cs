        [DataContract]
        public class MobEntity : NotifyBase
        {
            [Column]
            [DataMember]
            public DateTime RemoteLastUpdated { get; set; }
        }
    
    [Table]
    [DataContract]
    public class ToDoCategory : MobEntity , ISyncableBase
    {
        [IgnoreDataMember]
        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
        public int LocalId { get; set; }
    
        [Column(CanBeNull = true)]
        [DataMember(Name="id")]
        public int RemoteId { get; set; }
    
        [Column]
        [DataMember]
        public bool IsDeleted { get; set; }
    
        [Column]
        [DataMember]
        public DateTime RemoteLastUpdated { get; set; }
    
        [Column(CanBeNull = true)]
        [DataMember]
        public DateTime? LocalLastUpdated { get; set; }
    }
