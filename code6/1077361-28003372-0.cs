    public partial class Form3 : Form
    {
        public chart pie;
        Graphics graphics;
        public float d1;
        public float d2;
        public float d3;
        
        public Form3(chart ch)
        {
            InitializeComponent();
            pie = ch;
            graphics = pictureBox1.CreateGraphics();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           
           d1 = 360 * (((float)pie.r_count)/((float)pie.total_instr));
           d2 = 360 * (((float)pie.i_count) / ((float)pie.total_instr));
           d3 = 360 * (((float)pie.j_count) / ((float)pie.total_instr));
           //comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SolidBrush b1 = new SolidBrush (Color.Blue);
            SolidBrush b2 = new SolidBrush(Color.Red);
            SolidBrush b3 = new SolidBrush(Color.LawnGreen);
            Rectangle rect = new Rectangle(60,10,200,200);
            Pen p = new Pen(Color.Black);
            graphics.DrawPie(p, rect, 0, d1);
            graphics.FillPie(b1, rect, 0, d1);
            graphics.DrawPie(p, rect, d1, d2);
            graphics.FillPie(b2, rect, d1, d2);
            graphics.DrawPie(p, rect, d1 + d2, d3);
            graphics.FillPie(b3, rect, d1+d2, d3);
            comboBox1.SelectedIndex = 0;
            
                label1.Text = "R_type   (" + (d1 * 100 / 360).ToString() + "%)";
                label2.Text = "I_type   (" + (d2 * 100 / 360).ToString() + "%)";
                label3.Text = "J_type   (" + (d3 * 100 / 360).ToString() + "%)";
                label5.Enabled = false;
       
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label1.Text = "R_type   (" + (d1 * 100 / 360).ToString() + "%)";
                label2.Text = "I_type   (" + (d2 * 100 / 360).ToString() + "%)";
                label3.Text = "J_type   (" + (d3 * 100 / 360).ToString() + "%)";
                label5.Enabled = false;
            }
            else
            {
                label1.Text = "R_type   (" + (pie.r_count).ToString() + ")";
                label2.Text = "I_type   (" + (pie.i_count).ToString() + ")";
                label3.Text = "J_type   (" + (pie.j_count).ToString() + ")";
                label5.Text += "Total Instructions = " + pie.total_instr.ToString();
                label5.Enabled = true;
            }
        }
