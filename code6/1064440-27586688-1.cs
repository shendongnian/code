    // No MyHandler on any of the interfaces nor abstract classes
    public class CustomSerialDevice : AbstractProtocolSerialDevice, ICustomSerialDevice
    {
        [MyHandler]
        public override void Connect()
        { base.Connect(); }
        [MyHandler]
        public override void WriteCommand()
        { base.WriteCommand(); }
        [MyHandler]
        public override void ExecuteProtocolCommand()
        { base.ExecuteProtocolCommand(); }
        [MyHandler]
        public void ExecuteMyCommand()
        { /*omitted*/ }
    }
