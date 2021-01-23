    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Label positionOutput = new Label { Dock = DockStyle.Top };
            positionOutput.DataBindings.Add("Text", this, "Location");
            Label sizeOutput = new Label { Dock = DockStyle.Top };
            sizeOutput.DataBindings.Add("Text", this, "Size");
            this.Controls.Add(positionOutput);
            this.Controls.Add(sizeOutput);
        }
    }
