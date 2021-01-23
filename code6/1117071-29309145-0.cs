    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            // This triggers the infinite loop between the two controls
            numericUpDown1.Value = 10;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int cur = (int)numericUpDown2.Value;
            int r1 = r.Next(1, 100);
            while (r1 == cur)
                r1 = r.Next(1, 100);
            Console.WriteLine("Random in NUM1=" + r1);
            numericUpDown2.Value = r1;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int cur = (int)numericUpDown1.Value;
            int r1 = r.Next(1, 100);
            while (r1 == cur)
                r1 = r.Next(1, 100);
            Console.WriteLine("Random in NUM2=" + r1);
            numericUpDown1.Value = r1;
        }
    }
