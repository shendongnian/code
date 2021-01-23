    public partial class Form1 : Form
    {
        public ToolTip toolTip { get; set; }
        public Form1()
        {
            InitializeComponent();
            toolTip = new ToolTip();
            
            var watcher = new ControlWatcher();
            watcher.MouseEnter += watcher_MouseEnter;
            watcher.MouseLeave += watcher_MouseLeave;
            watcher.AddControl(listView1);
            watcher.StartListening();
        }
        void watcher_MouseEnter(Control control)
        {
            var pt = control.PointToClient(Cursor.Position);
            toolTip.Show("Super tooltip", control, pt);
        }
        void watcher_MouseLeave(Control control)
        {
            toolTip.Hide(control);
           
        }
    }
    public class ControlWatcher : IMessageFilter
    {
        public event Action<Control> MouseEnter;
        public event Action<Control> MouseLeave;
        private Control lastControl;
        private List<Control> controls;
        public ControlWatcher()
        {
            controls = new List<Control>();
        }
        public void StartListening()
        {
            Application.AddMessageFilter(this);
        }
        public void StopListening()
        {
            Application.RemoveMessageFilter(this);
        }
        public void AddControl(Control c)
        {
            controls.Add(c);
        }
        private bool IsMouseOverControl(Control control)
        {
            var pt = control.PointToClient(Cursor.Position);
            var isOver = (pt.X >= 0 && pt.Y >= 0 && pt.X <= control.Width && pt.Y <= control.Height);
            return isOver;
        }
        private void OnMouseEnter(Control control)
        {
            if (MouseEnter != null)
                MouseEnter(control);
        }
        private void OnMouseLeave(Control control)
        {
            if (MouseLeave != null)
                MouseLeave(control);
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg != 675 && m.Msg!=512)
            {
                return false;
            }
            //the control under the cursor
            var actControl = controls.FirstOrDefault(IsMouseOverControl);
          
            if (lastControl != null && actControl == null)
            {
                OnMouseLeave(lastControl);
                lastControl = null;
                return false;
            }
            if (lastControl==null && actControl != null && actControl != lastControl)
            {
                lastControl = actControl;
                OnMouseEnter(actControl);
                return false;
            }
            return false;
        }
    }
