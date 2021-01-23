    public partial class Form1 : Form
    {
        Random r = new Random();
        int num; // you cannot use r there
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
            num = r.Next(0, 100); // you can use r there
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            counter++;
            if (int.Parse(txt1.Text) > num)
            {
                lbl1.Text = "the number is too high";
                BackColor = SystemColors.HotTrack; // Form1 is the class
            }
            else {
                lbl1.Text = "the number is too low";
                BackColor = SystemColors.MenuHighlight; // Form1 is the class
            }
        }
    }
