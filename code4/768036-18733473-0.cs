    public partial class Form1 : Form
    {
        private void backColor_ColorChanged(object sender, EventArgs e)
        {
            if (redRadioButton.Checked)
                this.BackColor = System.Drawing.Color.Red;
            else if (blueRadioButton.Checked)
                this.BackColor = System.Drawing.Color.Blue;
            else if (greenRadioButton.Checked)
                this.BackColor = System.Drawing.Color.Green;
        }
        
        public Form1()
        {
            InitializeComponent();
            redRadioButton.CheckedChanged += new EventHandler(backColor_ColorChanged);
            blueRadioButton.CheckedChanged += new EventHandler(backColor_ColorChanged);
            greenRadioButton.CheckedChanged += new EventHandler(backColor_ColorChanged);
        }
    }
