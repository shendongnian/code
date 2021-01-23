    public partial class Terminal : XPCustomObject
    {
        Guid fOid;
        [Key(AutoGenerate = true), Browsable(false)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>("Oid", ref fOid, value); }
        }
        private Branch _Branch;
        [RuleRequiredField("", DefaultContexts.Save, "Branch required")]
        public Branch Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                SetPropertyValue("Branch", ref _Branch, value);
            }
        }
        string fDescription;
        [RuleUniqueValue("", DefaultContexts.Save, "The value was already registered within the system.", ResultType = ValidationResultType.Warning)]
        [RuleRequiredField("", DefaultContexts.Save, "Description required")]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>("Description", ref fDescription, value); }
        }
        string fIPAddress;
        [Size(15)]
        public string IPAddress
        {
            get { return fIPAddress; }
            set { SetPropertyValue<string>("IPAddress", ref fIPAddress, value); }
        }
        private int _Port;
        public int Port
        {
            get
            {
                return _Port;
            }
            set
            {
                SetPropertyValue("Port", ref _Port, value);
            }
        }
        string fDeviceDescription;
        public string DeviceDescription
        {
            get { return fDeviceDescription; }
            set { SetPropertyValue<string>("DeviceDescription", ref fDeviceDescription, value); }
        }
        private int _DeviceId;
        public int DeviceId
        {
            get
            {
                return _DeviceId;
            }
            set
            {
                SetPropertyValue("DeviceId", ref _DeviceId, value);
            }
        }
        private bool _Disabled;
        public bool Disabled
        {
            get
            {
                return _Disabled;
            }
            set
            {
                SetPropertyValue("Disabled", ref _Disabled, value);
            }
        }}
