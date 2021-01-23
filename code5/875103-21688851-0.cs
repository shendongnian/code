    public class DerpException : Exception
    {
        public override string StackTrace
        {
            get { return null; }
        }
    }
