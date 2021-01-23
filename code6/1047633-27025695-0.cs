    public partial class NewPasswordForm : Form {
        public Login LoginInfo { get; private set; }
        private void AddButton_Click(object sender, EventArgs e) {
            LoginInfo = new Login();
            //Do stuff with the four fields to create a Login
            //pass the login along with the DialogResult.OK below.
            this.DialogResult = DialogResult.OK;
            
            // If this is the last operation on the form, remember to close it.
            this.Close()
        }
    }
