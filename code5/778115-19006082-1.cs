    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent(); 
                
                var dataProvider = this.FindResource("xmlDataProvider") as XmlDataProvider;
                var doc = new XmlDocument();
                // Testdocument
                doc.LoadXml(
                     @"<root>
                        <child1>text1<child11>text11</child11>
                        </child1>
                        <child2>text2<child21>text21</child21>
                            <child22>text22</child22>
                        </child2>
                      </root>");
                dataProvider.Document = doc;
            }
        }
