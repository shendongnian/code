    public partial class Form1 : Form
    {
        private readonly int initialProgressbarLocationY;
        public Form1()
        {
            InitializeComponent();
            label1.MaximumSize = new Size(80, 1000); //Wrapping label
            label1.AutoSize = true;
            initialProgressbarLocationY = progressBar1.Location.Y; //Save the original position
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text += "bla blablablabla bla";
            MoveProgressbar();
        }
        private void MoveProgressbar()
        {
            // Set the progressbar at the same X, but update the Y according to the label's height
            progressBar1.Location = new Point(progressBar1.Location.X,
                initialProgressbarLocationY + label1.Height);
        }
    }
