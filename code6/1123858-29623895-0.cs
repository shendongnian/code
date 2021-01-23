    namespace Society_Accounting_Software
    {
    public partial class LoginScreen : Form
    {
        SqlConnection databaseConnect = new SqlConnection();
        
        public LoginScreen()
        {
            SqlConnection databaseConnect = new SqlConnection();
            databaseConnect.ConnectionString = "Data Source=GAURAV-PC;Initial Catalog=SocietyAccountingDatabase;Integrated Security=True";
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (!(UserNameTextBox.Text == string.Empty))
                {
                    if (!(PasswordTextBox.Text== string.Empty))
                    {
                       //this represent your connection to database
                        String str = "Data Source=GAURAV-PC;Initial Catalog=SocietyAccountingDatabase;Integrated Security=True";
                        String query = "select * from UserAccounts where userid = '"+UserNameTextBox.Text+"'and password = '"+this.PasswordTextBox.Text+"'";
                        SqlConnection con = new SqlConnection(str);
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader dbr;
                        con.Open();
                        dbr = cmd.ExecuteReader();
                        int count = 0;
                        while (dbr.Read())
                        {
                            count = count + 1;
                        }
                        con.Close();
                        if (count == 1)
                        {
                            AdminConsoleForm objmain = new AdminConsoleForm();
                            objmain.Show(); //after login Redirect to second window  
                            this.Hide();//after login hide the  Login window   
                        }
                        else if (count > 1)
                        {
                            MessageBox.Show("Duplicate username and password", "login page");
                        }
                        else
                        {
                            MessageBox.Show(" Username and Password Incorrect", "login page");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Password Empty", "login page");
                    }
                }
                else
                {
                    MessageBox.Show(" Username Empty", "login page");
                }
 
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            
        }
    }
    
