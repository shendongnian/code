    using System.IO;
    using System.Windows;
    using System.Xml.Serialization;
    
    namespace WpfApplication10
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
                var person = new Person {Payment = new Payment {Amount = 100}};
    
                var attributes = new XmlAttributes {XmlIgnore = true};
    
                var overrides = new XmlAttributeOverrides();
                overrides.Add(typeof (Person), "Payment", attributes);
    
                var serializer = new XmlSerializer(typeof (Person), overrides);
                using (var stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, person);
                    string s = stringWriter.ToString();
                }
            }
        }
    
        public class Person
        {
            public Payment Payment { get; set; }
            public int SomethingElse { get; set; }
        }
    
        public class Payment
        {
            public decimal Amount { get; set; }
        }
    }
