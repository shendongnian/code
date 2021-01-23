    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserControl1 prevUsr = pnlUI.Controls.OfType<UserControl1>().FirstOrDefault();
            UserControl1 usr = new UserControl1(prevUsr);
            usr.Back += usr_Back;
            pnlUI.Controls.Clear();
            pnlUI.Controls.Add(usr);
        }
        void usr_Back(UserControl1 sender, UserControl1 previous)
        {
            pnlUI.Controls.Remove(sender);
            if (previous != null)
            {
                pnlUI.Controls.Add(previous);
            }
        }
    }
