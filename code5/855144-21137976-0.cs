    public abstract class HwBase : IHw
    {
        protected void SendCommand(int x)
        {
            // Send the value of 'x' to the appropriate device
        }
        public virtual void SetLED();
    }
    public class Hw1 : HwBase
    {
        public override void SetLED()
        {
            // should send 0x20
            base.SendCommand(0x20);
        }
    }
    public class Hw2 : HwBase
    {
        public virtual void SetLED()
        {
            // should send 0x30
            base.SendCommand(0x30);
        }
    }
