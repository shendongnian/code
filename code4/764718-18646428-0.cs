    public partial class CharStats : Form
    {
        private MainForm _callingForm;
        public CharStats(MainForm callingForm)
        {
            InitializeComponent();
            _callingForm = callingForm;
        }
        private CharStats() : this (null)
        {
            // For designer use only.
        }
    
        void StatTransfer()
        {
            callingForm.SetInfo("Bob");
        }
    
        void FighterButtonClick(object sender, EventArgs e)
        {
            Fighter();
            StatTransfer();
        }
    }
