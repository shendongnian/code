    public partial class Form2 : Form
    {
        public string Result //TODO give better name
        {
            get { return textBox.Text; }
        }
        public string DisplayText //TODO give better name
        {
            get { return label.Text; }
            set { label.Text = value; }
        }
    }
