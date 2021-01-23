    public class EBusinessClassExceptions : ApplicationException
    {
        public override string Message
        {
            get
            {
                return this.GetType().ToString();
            }
        }
    }
