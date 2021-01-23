    namespace RunPackages
    {
        public partial class ListUpdater : Form
        {
            
            public ListUpdater()
            {            
                InitializeComponent();
                this.Load += new EventHandler(securityCheck);
            }    
    
            private void securityCheck(object sender, EventArgs e)
            {
                if (MyGlobals.FormCheck("MDM1") == 0)
                {
                    MessageBox.Show("Not allowed!");
                    this.Close();
                }    
            }
