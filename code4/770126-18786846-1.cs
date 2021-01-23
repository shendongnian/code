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
           
            panel1.BackColor = Color.Red;          
            panel2.BackColor = Color.Black;           
            panel3.BackColor = Color.Blue;
            panel4.BackColor = Color.Yellow;
            tableLayoutPanel1.Controls.Add(panel1,0,0);
            tableLayoutPanel1.Controls.Add(panel2,0,1);
            tableLayoutPanel1.Controls.Add(panel3,0,2);
            tableLayoutPanel1.Controls.Add(panel4,0,3);
        }
    }
