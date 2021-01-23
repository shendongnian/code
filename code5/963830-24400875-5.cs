     public partial class TestForm : Form
     {
        BLClass _bl;
        public TestForm()
        {
            InitializeComponent();
            //object of business layer
            _bl = new BLClass();
        }
        private void button1_Click(object sender, EventArgs e)
        {    
             //pass text boxes values to Business Layer         
            _bl.sUserName = textEdit_Name.Text;
            _bl.sUserPass = textEdit_Pass.Text;
            DataTable dt = _bl.GetDataTable();            
        }
     }
