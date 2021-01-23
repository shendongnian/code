    public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
                this.Load += new System.EventHandler(this.UserControl1_Load);
            }
            private void UserControl1_Load(object sender, EventArgs e)
            {
                if (this.ParentForm.Controls.OfType<UserControl1>().Count() > 1)
                {
                    //form already has a controler throw error
                    throw new System.Exception("you can have only one instance of me on a single form");
                    this.Enabled = false;
                    this.Dispose();
                }
            }
        }
