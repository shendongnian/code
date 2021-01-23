     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Panel panel1 = new Panel();
            Panel panel2 = new Panel();
            Panel panel3 = new Panel();
            Panel panel4 = new Panel();
           
            panel1t.BackColor = Color.Red;          
            panel2.BackColor = Color.Black;           
            panel3.BackColor = Color.Blue;
            panel4.BackColor = Color.Yellow;
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.Controls.Add(panel1);
            tableLayoutPanel1.Controls.Add(panel2);
            tableLayoutPanel1.Controls.Add(panel3);
            tableLayoutPanel1.Controls.Add(panel4);
        }
    }
