    // Main form
    private void OpenSomeForm()
    {
        SomeForm frm = new SomeForm(this);
        frm.Show();
    }
    // SomeForm
    public class SomeForm
    {
        private MainForm _mainForm;
        public SomeForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }
        private WriteToSerialPort()
        {
            _mainForm.comport.Write(/* stuff */);
        }
    }
