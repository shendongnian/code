    public class AddressingExtension : SoapExtension
    {
        public AddressingExtension()
            : base() { }
        public override object GetInitializer(Type serviceType)
        {
            return null;
        }
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return null;
        }
        public override void Initialize(object initializer)
        {
        }
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    AddAddressingHeaders(message);
                    break;
                default:
                    break;
            }
        }
        private void AddAddressingHeaders(SoapMessage message)
        {
            message.Headers.Add(new AddressingHeader());           
        }
    }
