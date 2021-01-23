    public partial class SetOperation : Form
    {
        public event Action<object> OnChDet;
        public SetOperation()
        {
            InitializeComponent();
            OnChDet += chDetDisplayHandler;
        }
        private void chDetDisplayHandler(object name)
        {
            ActFreqChan1.Text = "402.5";
        }
    }
