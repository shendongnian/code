    public partial class AAddIn : WPFAddInView
    {
        public FrameworkElement GetAddInUI()
        {
            return new AAddIn(); // creates a new instance of itself
        }
    }
