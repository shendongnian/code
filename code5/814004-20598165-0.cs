    public class WcfFriendlyStreamReader : StreamReader
    {
        public WcfFriendlyStreamReader(Stream s) : base(s) { }
        public override void Close()
        {
            base.Dispose(false);
        }
    }
