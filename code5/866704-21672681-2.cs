    using System;
    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Media;
    
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
                    bool foundRDStart = false;
                    bool foundRDEnd = false;
                    bool added = false;
                    while ((line = fs.ReadLine()) != null)
                    {
                        xaml += line;
                        if (!added)
                        {
    
                            if (line.Contains("<ResourceDictionary"))
                            {
                                foundRDStart = true;
                            }
                            if (foundRDStart && line.Contains(">"))
                            {
                                foundRDEnd = true;
                            }
                            if (foundRDStart && foundRDEnd)
                            {
                                added = true;
                                xaml += string.Format("<Color x:Key=\"OriginalBackground\">{0}</Color>",Background);
                            }
                        }
                    }
                    // Read in an EnhancedResourceDictionary File or preferably an GlobalizationResourceDictionary file
                    return XamlReader.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml))) as ResourceDictionary;
                }
            }
        }
    }
