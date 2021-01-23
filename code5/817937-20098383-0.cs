    public class UnclosableFileStream : StreamDecorator
    {
        public UnclosableFileStream(Stream original) : base(original)
        {
        }
        public override void Close()
        {
            
        }
        public void RealClose()
        {
            base.Close();
        }
    }
    public abstract class StreamDecorator : Stream
    {
         .... implements Stream base case
    }
