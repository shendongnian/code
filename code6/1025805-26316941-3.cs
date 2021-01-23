    public partial class Form1 : Form
    {
        private Form2 frm;
        public Form1()
        {
            InitializeComponent();
            frm = new Form2();
            frm.TeamInfoChanged += new Action<string>(frm_TeamInfoChanged);
            frm.Show();
        }
        void frm_TeamInfoChanged(string info)
        {
            Team1Lbl.Text = info;
        }
    }
