    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();            
        }
        Dictionary<Control,NativeControl> controls = new Dictionary<Control,NativeControl>();
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            OnMouseLeave(e);
        }                
        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.HandleCreated += ControlsHandleCreated;
            base.OnControlAdded(e);
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            e.Control.HandleCreated -= ControlsHandleCreated;
            base.OnControlRemoved(e);
        }
        private void ControlsHandleCreated(object sender, EventArgs e)
        {
            Control control = sender as Control;
            NativeControl nc;
            if(!controls.TryGetValue(control, out nc)) {
               nc = new NativeControl(this);
               controls[control] = nc;
            }
            nc.AssignHandle(control.Handle);            
        }        
        public class NativeControl : NativeWindow
        {
            public NativeControl(UserControl1 parent)
            {
                Parent = parent;
            }
            UserControl1 Parent;
            bool entered;
            protected override void WndProc(ref Message m)
            {
                //WM_MOUSEMOVE = 0x200
                //WM_LBUTTONDOWN = 0x201
                //WM_LBUTTONUP = 0x202
                //WM_NCHITTEST = 0x84
                if (m.Msg == 0x200 || m.Msg == 0x201 || m.Msg == 0x202 || m.Msg == 0x84){
                    //Check if Parent is not nul, pass these messages to the parent
                    if (Parent != null){
                        m.HWnd = Parent.Handle;
                        Parent.WndProc(ref m);
                    }
                    if (m.Msg == 0x200 && !entered){
                        entered = true;
                        Parent.OnMouseEnter(EventArgs.Empty);
                    }
                    else entered = false;
                }
                else if (entered) entered = false;
                base.WndProc(ref m);                
            }
        }
    }
