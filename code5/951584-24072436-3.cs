    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Xml;
    using System.Xml.Serialization;
    namespace WPFXMLTest {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();            
                DataBaseUpdate dbUpdate = DataBaseUpdate.FromXML(System.IO.File.ReadAllBytes(@"c:\temp\stackOverflow.xml"));
                if (dbUpdate != null) {
                    this.dataGrid.ItemsSource = dbUpdate.InsertTFSQueryList;
                }
            }
        }
        [XmlRoot(ElementName="DataBaseUpdate")]
        public class DataBaseUpdate {
            public DataBaseUpdate() {
            }
            public static DataBaseUpdate FromXML(byte[] xmlBytes) {
                DataBaseUpdate dbUpdate = null;
                using (MemoryStream ms = new MemoryStream(xmlBytes)) {                
                    XmlSerializer xs = new XmlSerializer(typeof(DataBaseUpdate));
                    dbUpdate = xs.Deserialize(ms) as DataBaseUpdate;
                }
                return dbUpdate;
            }
            [XmlElement(ElementName="inserttfsquery")]        
            public List<InsertTFSQuery> InsertTFSQueryList { get; set; }
        }
        public class InsertTFSQuery {
            public InsertTFSQuery() {
            }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "chargenumber")]
            public string Chargenumber { get; set; }
            [XmlAttribute(AttributeName = "length")]
            public string Length { get; set; }
            [XmlAttribute(AttributeName = "translateddigits")]
            public string Translateddigits { get; set; }
            [XmlAttribute(AttributeName = "objectclass")]
            public string Objectclass { get; set; }
            [XmlAttribute(AttributeName = "carrierid")]
            public string Carrierid { get; set; }
            [XmlAttribute(AttributeName = "originatingdigits")]
            public string Originatingdigits { get; set; }
            [XmlAttribute(AttributeName = "expiration")]
            public string Expiration { get; set; }
            [XmlAttribute(AttributeName = "dialeddigits")]
            public string Dialeddigits { get; set; }
        }
    }
