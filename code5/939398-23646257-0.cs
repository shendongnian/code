    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(140, 140);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            moveFormToPanel(panel2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            moveFormToPanel(panel3);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            moveFormToPanel(panel4);
        }
        private void moveFormToPanel(Panel panel)
        {
            this.Location = this.Location + new Size(panel.Location.X, panel.Location.Y);
            this.panel1.Visible = false;
            panel.Location = this.panel1.Location;
            panel.Visible = true;
        }
    }
