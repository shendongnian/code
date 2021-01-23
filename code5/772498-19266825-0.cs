        public partial class CustomForm : UserControl
    {
        public CustomForm()
        {
            InitializeComponent();
            flowLayoutPanel = new FlowLayoutPanel();
            this.Controls.Add(flowLayoutPanel);
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            Forms = new Dictionary<string, TextBox>();
        }
        private FlowLayoutPanel flowLayoutPanel;
        private Dictionary<string, TextBox> Forms;
        public void AddForm(string label, TextBox textBox)
        {
            Forms.Add(label, textBox);
            Panel panel = new Panel();
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;
            flp.Controls.Add(new Label {Text = label, AutoSize = true});
            flp.Controls.Add(textBox);
            flp.AutoSize = true;
            panel.Controls.Add(flp);
            panel.AutoSize = true;
            flowLayoutPanel.Controls.Add(panel);
        }
        public string GetTextBoxValue(string label)
        {
            return Forms.ContainsKey(label) ? Forms[label].Text : "";
        }
        public void SetTextBoxValue(string label, string value)
        {
            if (Forms.ContainsKey(label))
            {
                Forms[label].Text = value;
            }
        }
    }
