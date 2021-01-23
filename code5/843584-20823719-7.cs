    public partial class Login : Form
    {
        public Login() 
        { 
           InitializeComponent(); 
        }
        public User User { get; private set; }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var repository = new UserRepository();
            User = repository.GetUser(txtUser.Text, txtPass.Text);
            if (User == null)
            {
                MessageBox.Show("Wrong ID/Pass");
                DialogResult = DialogResult.Cancel;
                return;
            }
            if (User.IsAdmin)            
                MessageBox.Show("Hello " + User.Name, "Admin", 
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);            
            else            
                MessageBox.Show("Welcome " + User.Name, "User");
            DialogResult = DialogResult.OK;
        }
        private void RequiredTextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (String.IsNullOrEmpty(textBox.Text))
            {
                errorProvider.SetError(textBox, "Required");
                return;
            }
            errorProvider.SetError(textBox, "");
        }
    }
