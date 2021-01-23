    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Windows.Markup;
    
    namespace BackgroundAnimationBlend
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var rd2 = LoadFromFile();
                this.Resources.MergedDictionaries.Add(rd2);
            }
    
            public ResourceDictionary LoadFromFile()
            {
                const string file = "Styles/StoryBoardResourceDictionary.xaml";
    
                if (!File.Exists(file))
                    return null;
    
                using (var fs = new StreamReader(file))
                {
                    string xaml = string.Empty;
                    string line;
                    bool replaced = false;
                    while ((line = fs.ReadLine()) != null)
                    {
                        if (!replaced)
                        {
                            if (line.Contains("OriginalBackground"))
                            {
                                xaml += string.Format("<Color x:Key=\"OriginalBackground\">{0}</Color>", Background);
                                replaced = true;
                                continue;
                            }
                        }
                        xaml += line;
                    }
                    // Read in an EnhancedResourceDictionary File or preferably an GlobalizationResourceDictionary file
                    return XamlReader.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml))) as ResourceDictionary;
                }
            }
        }
    }
