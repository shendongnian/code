    [AttributeUsage(AttributeTargets.Method)]
    public class AddressingExtensionAttribute : SoapExtensionAttribute
    {
        private string action;
        private int priority;
        public AddressingExtensionAttribute()
            : base()
        {
            this.action = "defaultaction";
        }
        public override Type ExtensionType
        {
            get
            {
                return typeof(AddressingExtension);
            }
        }
        public override int Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }
        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
    }
