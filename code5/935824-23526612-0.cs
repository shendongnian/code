    using System.IO;
    using System.Windows;
    using System.Xml.Serialization;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                // Create XML sample data
                var settings = new MySettings {Setting1 = "hello !", Setting2 = "hi !"};
                var serializer1 = new XmlSerializer(typeof (MySettings));
                string xml;
                using (TextWriter textWriter = new StringWriter())
                {
                    serializer1.Serialize(textWriter, settings);
                    xml = textWriter.ToString();
                }
    
                // Deserialize that sample data to an object
                var serializer2 = new XmlSerializer(typeof (MySettings));
                MySettings deserialize;
                using (var stringReader = new StringReader(xml))
                {
                    deserialize = serializer2.Deserialize(stringReader) as MySettings;
                }
    
                // Use deserialized data as our context
                if (deserialize != null)
                {
                    DataContext = deserialize;
                }
            }
        }
    
        public class MySettings
        {
            public string Setting1 { get; set; }
            public string Setting2 { get; set; }
        }
    }
