    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(@"C:\tmp\date.txt"))
            {
                File.WriteAllText(@"C:\tmp\date.txt", DateTime.Now.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dn = DateTime.Now;
            DateTime dt = DateTime.Parse(File.ReadAllText(@"C:\tmp\date.txt"));
                              // Read the Text ^      From the File ^
            TimeSpan dc = dn - dt;
            label1.Text = "Now: " + dn.ToString() +
                        "\nThen: " + dt.ToString() +
                        "\nDifference..." +
                        "\nDays: " + dc.Days.ToString() +
                        "\nHours: " + dc.Hours.ToString() +
                        "\nMins: " + dc.Minutes.ToString() +
                        "\nSecs: " + dc.Seconds.ToString();
        }
    }
