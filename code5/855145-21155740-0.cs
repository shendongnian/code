    public abstract class HwBase<T> where T : CmdBase, new()
    {
        protected static readonly T Commands = new T();
        public virtual void SetLED()
        {
            SendCommand(Commands.SET_LED); // 0x10
        }
    }
    public class Hw1 : HwBase<Cmd1>
    {
        public override void SetLED()
        {
            SendCommand(Commands.SET_LED); // 0x20
        }
    }
    public class Hw2 : HwBase<Cmd2>
    {
        public override void SetLED2()
        {
            SendCommand(Commands.SET_LED_2); // 0x30
        }
    }
