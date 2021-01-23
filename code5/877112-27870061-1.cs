    namespace WpfApplication1
    {
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            createSourateFromXML();
        }
        private void createSourateFromXML()
        {
            string xmlquranfile = @"C:\Users\hp\Downloads\quran-simple.xml";
            XmlDocument xml_quran = new XmlDocument();
            xml_quran.Load(xmlquranfile);
            foreach (XmlNode soura in xml_quran.DocumentElement.ChildNodes)
            {
                writeToTextBox(soura.Attributes["name"].Value);
            }
        }
        private void writeToTextBox(string textToWrite)
        {
            textBox1.Text += textToWrite + "\n";
        }
    }
