    public abstract class CustomEntity : ITableData
    {
       // protected CustomEntity();
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [TableColumn(TableColumnType.CreatedAt)]
        public DateTimeOffset? CreatedAt { get; set; }
        [TableColumn(TableColumnType.Deleted)]
        public bool Deleted { get; set; }
        [Key]   
        [TableColumn(TableColumnType.Id)]
        public string Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [TableColumn(TableColumnType.UpdatedAt)]
        public DateTimeOffset? UpdatedAt { get; set; }
        [TableColumn(TableColumnType.Version)]
        [Timestamp]
        public byte[] Version { get; set; }
    } 
