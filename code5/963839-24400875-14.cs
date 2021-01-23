     public partial class LoginForm : Form
     {
        BLClass _bl;
        public LoginForm()
        {
            InitializeComponent();
            //object of business layer
            _bl = new BLClass();
        }
        private void button1_Click(object sender, EventArgs e)
        {    
            //pass text boxes values to Business Layer      
            DataTable dt = _bl.GetDataTable(textEdit_Name.Text, textEdit_Pass.Text);            
        }
     }
