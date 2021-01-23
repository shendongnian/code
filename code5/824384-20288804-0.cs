    [Table("ReminderSetting")]
    public class ReminderSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [ForeignKey("Setting")]
        public int SettingId { get; set; }
    
        public string Login { get; set; }
        public bool Value { get; set; }
    
        public virtual Setting Setting { get; set; }
    }
    [Table("Settings")]
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Title { get; set; }
    
        public virtual ReminderSetting ReminderSetting { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReminderSetting>()
            .HasKey(r => r.SettingId);
        modelBuilder.Entity<ReminderSetting>()
                    .Property(r => r.SettingId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        modelBuilder.Entity<ReminderSetting>()
                    .HasRequired(r => r.Setting)
                    .WithRequiredDependent(s => s.ReminderSetting);
    
        base.OnModelCreating(modelBuilder);
    }
