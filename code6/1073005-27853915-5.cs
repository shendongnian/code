    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClickLogger.AttachLogging<Button>(Controls);
            ClickLogger.LogClick += (sender, e) =>
            {
                textBox1.AppendText(string.Format("{0} -- {1}\r\n", e.DateTime, e.Name));
            };
        }
    }
