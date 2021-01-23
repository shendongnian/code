    public class Module2601_VM
    {
        private Module2601_VMChildrenDescriptor module2601_VMChildrenDescriptor;
        public Module2601_VM()
        {
            module2601_VMChildrenDescriptor = new Module2601_VMChildrenDescriptor(this);
            ListModules = new Module2610_VMCollection();
            ListCOM = new ComPort_VMCollection();
        }
    
        public string GatewayName {get; set;}
        public string FirmwareVersion { get; set; }
        public string IPAddress { get; set; }
        public string NbIoms { get; set; }
        public Module2610_VMCollection ListModules { get; set; }
        public ComPort_VMCollection ListCOM { get; set; }
    
        public IEnumerable Children
        {
            get
            {
                return module2601_VMChildrenDescriptor;
            }
        }
    }
