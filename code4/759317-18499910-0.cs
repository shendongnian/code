    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // attach this event handler before the text/size changes
            labelName.SizeChanged += labelName_SizeChanged;
            labelName.Text = "really really really really long text gets set here.........................";
        }
        void labelName_SizeChanged(object sender, EventArgs e)
        {
            AdjustLabelPosition();
        }
        private void AdjustLabelPosition()
        {
            if (labelShareSize.Left < labelName.Location.X + labelName.Width)
                labelShareSize.Left = labelName.Location.X + labelName.Width;
        }
    }
