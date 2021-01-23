    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string Name { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            XPathDocument document = new XPathDocument(Application.StartupPath + "/InfoR.xml");
            XPathNavigator navigator = document.CreateNavigator();
            XPathNavigator node = navigator.SelectSingleNode("//appsettings/name");
            Name = node.InnerXml;
        }
    }
