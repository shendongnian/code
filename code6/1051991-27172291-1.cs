    public partial class MainWindow : Window
        {
    
            List<string> config = new List<string>() { "tree", "1", "chair", "4", "window", "3", "dollar", "200" };
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void tree_Click(object sender, RoutedEventArgs e)
            {
                SetConfig(config, this.tree.Name);
            }
    
            private void chair_Click(object sender, RoutedEventArgs e)
            {
                SetConfig(config, this.chair.Name);
            }
    
            public void SetConfig(List<string> config, string name)
            {
                config[config.IndexOf(name) + 1] = ((Button)LayoutRoot.FindName(name)).Content.ToString();
    
            }       
        }
