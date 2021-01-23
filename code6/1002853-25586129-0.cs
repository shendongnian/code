    class CtlWrapper
    {
        public string Text { get; set; }
        public Control theControl { get; private set; }
        public CtlWrapper(string text)
        {
            Text = text;
            theControl = new Control();
            theControl.Text = text;
        }
        public override string ToString() { return Text; }
    }
