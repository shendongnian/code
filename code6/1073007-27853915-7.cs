    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClickLogger.SubscribeClick(button1, button_Click);
            ClickLogger.SubscribeClick(button2, button_Click);
            ClickLogger.SubscribeClick(button3, button_Click);
            ClickLogger.LogClick += (sender, e) =>
            {
                textBox1.AppendText(string.Format("{0} -- {1}\r\n", e.DateTime, e.Name));
            };
        }
        private void button_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(string.Format("==> clicked {0}\r\n", ((Control)sender).Name));
        }
    }
