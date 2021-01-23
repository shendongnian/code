    public partial class PrinterSelectView : Form, IPrinterSelectView
    {
        public event Action Canceled = () => { }; // will never be null now
        public event Action Saved = () => { };
        // ...
    }
