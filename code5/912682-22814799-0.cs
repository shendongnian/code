    class Dragger
    {
        private readonly Form _parent;
        private Panel _dragee;
        public Dragger(Form parent)
        {
            _parent = parent;
        }
        public void MouseMoved(object sender, MouseEventArgs e)
        {
            if (_dragee != null)
            {
                _dragee.Location = _parent.PointToClient(Cursor.Position);
            }
        }
        public void StartDragging(Panel panel)
        {
            _dragee = panel;
        }
        public void StopDragging()
        {
            _dragee = null;
        }
    }
    public partial class Form1 : Form
    {
        private readonly Dragger _dragger;
        public Form1()
        {
            InitializeComponent();
            _dragger = new Dragger(this);
            panel1.MouseMove += _dragger.MouseMoved;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseUp += panel1_MouseUp;
        }
        void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragger.StopDragging();
        }
        void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            
            _dragger.StartDragging((Panel)sender);
        }
    }
