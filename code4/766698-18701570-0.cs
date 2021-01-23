    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            foreach (var i in FindIndicies("text"))
            {
                this.textBox1.SelectionStart = i;
                this.textBox1.SelectionLength = "text".Length;
                var result = MessageBox.Show(
                    "Move to the next index?",
                    "Next?",
                    MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No) { break; }
            }
        }
        private List<int> FindIndicies(string textToFind)
        {
            var indicies = new List<int>();
            var offset = 0;
            var i = 0;
            while ((i = this.textBox1.Text.IndexOf(
                textToFind,
                offset,
                StringComparison.CurrentCultureIgnoreCase)) > 0)
            {
                indicies.Add(i);
                offset = (i + textToFind.Length);
            }
            return indicies;
        }
    }
