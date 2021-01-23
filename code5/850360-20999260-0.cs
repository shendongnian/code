    public class Device
    {
        //You need the Key annotation because the name does not follow the 
        //convention for a Key
        //if you'd called it "DeviceID" or "ID" then you wouldn't need it
        [Key]
        //EF defaults int keys to Identity
        //assuming longs are the same you need this annotation to stop that
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DeviceSerial { get; set; }
        
        //This is a navigation property. 
        //The virtual keyword lets EF override the method in a proxy class 
        //so that it can support lazy loading. 
        //Convention would name it "DeviceLogEntries"
        public virtual ICollection<DeviceLogEntry> Errors { get; set; }
    }
    
    public class DeviceLogEntry
    {        
        //You don't need the Key annotation
        public int Id { get; set; }        
        //You don't have to include the foreign key AND the navigation property
        //in the entity but life is probably easier if you do...
        public long DeviceSerial { get; set; }
    
        //...so I would add the navigation property to your entity
        //Foreign key doesn't follow convention (it's not "DeviceID")
        //so you need to tell it what it is
        [ForeignKey("DeviceSerial")]
        //And again if the navigation property in the parent had been named 
        //"DeviceLogEntries" then you wouldn't need to tell EF that the 
        //inverse navigation property is actually called "Errors"  
        [InverseProperty("Errors")]
        public virtual Device Device {get;set;)
    }
