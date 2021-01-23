    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var elementHost = new ElementHost
            {
                Dock = DockStyle.Fill,
                Child = new ListBoxSample()
            };
            Controls.Add(elementHost);
        }
    }
