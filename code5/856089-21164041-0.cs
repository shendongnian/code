    namespace Equipment.Models
    {
        public class Device
        {
            public int DeviceId { get;set; }
            [Required]
            [StringLength(14)]
            public string DeviceUser { get; set; }
            [ForeignKey("DeviceDictionaryId")]
            public int DeviceDictionaryId { get; set; }
        }
        public class DeviceDBContext: DbContext
        {
            public DbSet<Device> Devices {get; set;}
        }
    
    }
