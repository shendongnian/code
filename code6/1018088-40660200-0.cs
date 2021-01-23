    public partial class EntryReportInventory
    {
        public Guid DeviceId { get; set; }
        [ReportProperty]
        public string DeviceName { get; set; }
    
        public Dictionary<string, object> InventoryValues { get; set; }
    
        public EntryReportInventory(Device device, Dictionary<string, object> inventoryValues)
        {
            this.DeviceId = device.Id;
            this.DeviceName = device.Name;
            
            this.InventoryValues = inventoryValues;
        }
    }
