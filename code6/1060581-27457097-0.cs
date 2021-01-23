    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int visibleLabelCount = 0;
            foreach (Label label in Controls.OfType<Label>())
            {
                // Check property, in case some Label is initialized as not
                // visible in the Designer
                if (label.Visible)
                {
                    visibleLabelCount++;
                }
                label.VisibleChanged += (sender, e) =>
                {
                    visibleLabelCount += ((Label)sender).Visible ? 1 : -1;
                    if (visibleLabelCount <= 0)
                    {
                        Close();
                    }
                }
            }
        }
    }
