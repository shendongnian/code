    public partial class Form1 : Form
    {
        private  Label myLabel;
        public Form1()
        {
            InitializeComponent();
            myLabel = new Label();
            this.Controls.Add(myLabel);
            myLabel.Location = new Point(50, 50);
            myLabel.Text = "Yay!";
        }
        private void button1_Click(object sender, EventArgs e)
        {
           this.Controls.Remove(myLabel);
        }
