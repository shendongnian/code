    public class MessageA : IMessage
    {
        public bool Handled
        {
            get;
            private set;
        }
        public void MarkAsHandled()
        {
            this.Handled = true;
        }
    }
    public class MessageB : IMessage
    {
        public bool Handled
        {
            get;
            private set;
        }
        public void MarkAsHandled()
        {
            this.Handled = true;
        }
    }
