    public partial class DeviceUsage
    {
        [Key] 
        [Column(Order=1)] 
        public int StorageId { get; set; }
        [Key] 
        [Column(Order=2)] 
        public int UserId { get; set; }
        [Key] 
        [Column(Order=3)] 
        public int DeviceInstanceId { get; set; }
    
        public virtual DeviceInstance DeviceInstance { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual User User { get; set; }
    }
