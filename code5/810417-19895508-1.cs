    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Shown += new EventHandler(Form2_Shown);
            this.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
        }
        void Form2_Shown(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Hide();
            }
        }
        void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }
    }
