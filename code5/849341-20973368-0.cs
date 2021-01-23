    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var login=new LoginForm();
            if(login.ShowDialog()==DialogResult.OK)
            {
                // Validation ok
            }
            else
            {
                this.Close();
            }
        }
    }
