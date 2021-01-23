    public abstract partial class Epl2CommandBase : IEpl2Command
    {
        protected Epl2CommandBase() { }
        public virtual byte[] GenerateByteCommand()
        {
            return Encoding.ASCII.GetBytes(CommandString + '\n');
        }
        public abstract string CommandString { get; set; }
    }
