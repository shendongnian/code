    public partial class frmLogin : Form
    {
        #region "Properties"
        private bool _Authenticated = false;
        public bool Authenticated
        {
            get { return _Authenticated; }
            set { _Authenticated = value; }
        }
        #endregion
     public void Login()
        {
            
            if (GetLoginAuthentication(cbxLoginName, txbPassword))
            {
                this.Hide();
                //MessageBox.Show("Successfull");
                Authenticated = true;
                //frmCommissionReport frm = new frmCommissionReport();
                //frm.ShowDialog();
              
            }
            else
            {
                Authenticated = false;
                MessageBox.Show("Username or Password not recognised");
            }
        }
