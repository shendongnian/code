    public partial class Form1 : Form
    {
        Dictionary<string, string> tags = new Dictionary<string, string>() { 
        { "00000919BEAE", "Milk" } ,
        {"0000092A1132", "Fruits"}};
        public string RxString { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void DisplayText(object sender, EventArgs e)
        {
            textBox1.AppendText(RxString);
            if (tags.ContainsKey(RxString))
            {
                textBox1.AppendText(RxString + ":" + tags[RxString]); 
            }
        }
    }
