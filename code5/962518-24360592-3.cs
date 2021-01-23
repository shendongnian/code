    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node();
            n1.SetControl(new TextBox());
            Node n2 = new Node();
            n2.SetControl(new Button());
        }
    }
    class Node
    {
        private ControlWrapper _link;
        public ControlWrapper Link
        {
            get { return _link; }
        }
        public void SetControl<TControl>(TControl control)
            where TControl : System.Windows.Forms.Control
        {
            ControlWrapper prevLink = Link;
            if (prevLink != null)
                prevLink.Dispose();
            _link = new ControlWrapper<TControl>(this, control);
        }
    }
    // microsoft basic dispose pattern
    // http://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx#basic_pattern
    abstract class ControlWrapper : IDisposable
    {
        private readonly Node _node;
        private readonly Control _control;
        public Node Node
        {
            get { return _node; }
        }
        public Control Control
        {
            get { return _control; }
        }
        public ControlWrapper(Node node, Control control)
        {
            if (node == null)
                throw new ArgumentNullException("node");
            if (control == null)
                throw new ArgumentNullException("control");
            _node = node;
            _control = control;
        }
        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_control != null)
                    _control.Dispose();
            }
        }
    }
    class ControlWrapper<TControl> : ControlWrapper
        where TControl : System.Windows.Forms.Control
    {
        public TControl Control
        {
            get { return (TControl)base.Control; }
        }
        public ControlWrapper(Node node, TControl control)
            : base (node, control)
        {
        }
    }
