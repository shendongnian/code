    public partial class aboutForm: Form
    {      
        public aboutForm()
        {
            InitializeComponent();
        }
        private void aboutForm_Load(object sender, EventArgs e)
        {
           this.FormClosing +=new FormClosingEventHandler(aboutForm_FormClosing);
        }
        private void aboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
    
            
