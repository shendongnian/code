    public class MyDbContext: DbContext
    {
        public DbSet<Device> Devices {get; set;}
        public DbSet<DeviceDictionary> Dictionaries { get; set; }
    }
