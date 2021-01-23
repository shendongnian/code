    public class DeviceType
    {
        public long Id { get; set; }
            
        public virtual ICollection<SoftwareFirmware> AvailableVerions { get; private set; }
        public virtual IEnumerable<Firmware> AvailableFirmwareVerions
        {
            get
            {
                return this.AvailableVerions.OfType<Firmware>();
            }
        }
        public virtual IEnumerable<Software> AvailableSoftwareVerions
        {
            get
            {
                return this.AvailableVerions.OfType<Software>();
            }
        }
    
        public DeviceType()
        {
            AvailableVerions = new HashSet<SoftwareFirmware>();
        }
    }
