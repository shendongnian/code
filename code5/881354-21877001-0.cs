    public class MyUserControl : UserControl
    {
        public new Control.ControlCollection Controls
        {
            get { throw new NotSupportedException(); }
        }
    }
