Let take a look at commented lines
    public partial class Form1 : Form
    {
        //prevUsr  is global instead
        private UserControl1 prevUsr = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //prevUsr is removed from here
            //UserControl1 prevUsr = pnlUI.Controls.OfType<UserControl1>().FirstOrDefault();
            UserControl1 usr = new UserControl1(prevUsr);
            usr.Back += usr_Back;
            pnlUI.Controls.Clear();
            pnlUI.Controls.Add(usr);
            //prevUsr is updated
            prevUsr = usr;
        }
        void usr_Back(UserControl1 sender, UserControl1 previous)
        {
            pnlUI.Controls.Remove(sender);
            //prevUsr is updated
            prevUsr = previous;
            if (previous != null)
            {
                pnlUI.Controls.Add(previous);
            }
        }
    }
