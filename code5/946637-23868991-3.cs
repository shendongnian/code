    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var table = new Table();
            IEnumerable<Control> controls = table.Render(10, 10);
            foreach (var control in controls)
            { this.Controls.Add(control); }
        }
    }
