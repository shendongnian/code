    class Node
    {
        public ControlWrapper Link { get; set; }
    }
    abstract class ControlWrapper
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
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node();
            n1.Link = new ControlWrapper<TextBox>(n1, new TextBox());
            Node n2 = new Node();
            n2.Link = new ControlWrapper<Button>(n2, new Button());
        }
    }
