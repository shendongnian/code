    class CtlWrapper
    {
        public Control theControl { get; private set; }
        public CtlWrapper(string text)
        {
            theControl = new Control();
            theControl.Text = text;
        }
        public CtlWrapper(Control control) { theControl = control; } // for fun
        public override string ToString() { return theControl.Text; }
    }
