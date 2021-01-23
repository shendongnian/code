    public partial class Form1 : Form
    {
        private Rectangle buttonRectangle;
        private bool checkRectangle = false;
        public Form1()
        {
            InitializeComponent();
            button2.TabStop = false;
            buttonRectangle = button2.ClientRectangle;
            buttonRectangle.Location = button2.Location;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Location = new Point(25, 25);
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Location = new Point(50, 50);
            checkRectangle = true;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!checkRectangle)
            {
                return;
            }
            if (!buttonRectangle.Contains(e.X, e.Y))
            {
                checkRectangle = false;
                button2.Location = buttonRectangle.Location;
            }
        }
    }
