     public abstract class PluginBase
    {
        public abstract void Initialize();
        protected void showControl(UserControl control)
        {
            ShowControl(this, new ControlToBeShownEventArgs() { TheControl = control });
        }
        public event EventHandler<ControlToBeShownEventArgs> ShowControl = delegate { };
    }
    public class ControlToBeShownEventArgs : EventArgs
    {
        public UserControl TheControl { get; set; }
    }
