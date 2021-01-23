      public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                LoadXAML();
            }
    
            public void LoadXAML()
            {
                try
                {
                    using (StreamReader xamlStream = new StreamReader(@"C:\WpfApplication1\WpfApplication1\DynamicWindow.xaml"))
                    {
                        var context = new ParserContext();
                        context.XamlTypeMapper = new XamlTypeMapper(new string[] { });
                        context.XmlnsDictionary.Add("c", "clr-namespace:WpfApplication1");
                        context.XamlTypeMapper.AddMappingProcessingInstruction("clr-namespace:WpfApplication1", "WpfApplication1", "WpfApplication1");
    
                        string xamlString = xamlStream .ReadToEnd();
    
                        DependencyObject rootObject = XamlReader.Parse(xamlString, context) as DependencyObject;
                        cntControl.Content = rootObject; //cntControl is a content control I placed inside MainWindow
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
