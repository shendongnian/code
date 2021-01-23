    public partial class frmMain : Form 
    { 
        frmLogin _login = new frmLogin(); 
 
 
        public frmMain() 
        { 
            InitializeComponent(); 
            _login.ShowDialog(); 
            if (_login.Authenticated) 
            { 
                MessageBox.Show("You have logged in successfully " + _login.Username); 
            } 
            else 
            { 
                MessageBox.Show("You failed to login or register - bye bye","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                Application.Exit(); 
            } 
        } 
    } 
