    namespace WpfApplication5
    {
        public partial class MainWindow : Window
        {
            public MainWindow() {
                InitializeComponent();
    
                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                stackPanel.Children.Add(new ProgressBar { Height = 15, Width = 160 });
                stackPanel.Children.Add(new TextBlock { Foreground = new SolidColorBrush(Colors.Red), Text = "Quux" });
    
                var item = new TreeViewItem { Header = stackPanel };
                treeView1.Items.Add(item);
            }
        }
    }
