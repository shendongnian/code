    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.radioButton1.CheckedChanged += new System.EventHandler(this.HandleCheckedChanged);
            this.radioButton2.CheckedChanged += new System.EventHandler(this.HandleCheckedChanged);
            this.radioButton3.CheckedChanged += new System.EventHandler(this.HandleCheckedChanged);
        }
        private bool changing = false;
        private void HandleCheckedChanged(object sender, EventArgs e)
        {
            if (!changing)
            {
                changing = true;
                if (sender == this.radioButton1)
                {
                    this.radioButton2.Checked = !this.radioButton1.Checked;
                    this.radioButton3.Checked = !this.radioButton1.Checked;
                }
                else if (sender == this.radioButton2)
                {
                    this.radioButton1.Checked = !this.radioButton2.Checked;
                    this.radioButton3.Checked = !this.radioButton2.Checked;
                }
                else if (sender == this.radioButton3)
                {
                    this.radioButton1.Checked = !this.radioButton3.Checked;
                    this.radioButton2.Checked = !this.radioButton3.Checked;
                }
                changing = false;
            }
        }
    }
