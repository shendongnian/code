    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SelectTextBoxes = new List<TextBox>() { textBox1, textBox2, textBox3 }; // list the textboxes here
        }
        private List<TextBox> SelectTextBoxes = new List<TextBox>(); 
        protected override bool ProcessTabKey(bool forward)
        {
            Control ctl = this.ActiveControl;
            if (ctl != null && ctl is TextBox)
            {
                TextBox tb = (TextBox)ctl;
                if (SelectTextBoxes.Contains(tb) && tb.Text.Length == 0)
                {
                    return true;
                }
            }
            return base.ProcessTabKey(forward); // process TAB key as normal
        }
    }
