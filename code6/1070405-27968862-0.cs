    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int count = 0;
        private LinkedList<UserControl1> lstControls = new LinkedList<UserControl1>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var c = new UserControl1();
            if (pnlUI.Controls.Count > 0)
            {
                lstControls.AddLast(pnlUI.Controls[0] as UserControl1);
                pnlUI.Controls.Clear();
            }
            c.lblTitle.Text = "Control #" + (++count).ToString();
            pnlUI.Controls.Add(c);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lstControls.Last != null)
            {
                var lastControl = lstControls.Last.Value;
                pnlUI.Controls.Clear();
                pnlUI.Controls.Add(lastControl);
                lstControls.RemoveLast();
            }
        }
    }
