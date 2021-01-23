    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int x = 0; x < 10; x++)
            {
                StackPanel sp = new StackPanel();
                Button upbt = new Button();
                Button dwbt = new Button();
                upbt.Click += bt_Click;
                dwbt.Click+= bt_Click;
                upbt.Tag = "up";
                dwbt.Tag = "down";
                upbt.Content = "Up";
                dwbt.Content = "Down";
                sp.Orientation = Orientation.Vertical;
                sp.Children.Add(upbt);
                sp.Children.Add(dwbt);
                mylb.Items.Add(sp);
            }
        }
        void bt_Click(object sender, RoutedEventArgs e)
        {
            Button but = (sender as Button);
            var par = but.Parent;
            string tag = but.Tag.ToString();
            if (par is StackPanel)
            {
                StackPanel sp = (par as StackPanel);
                int index = mylb.Items.IndexOf(sp);
                List<StackPanel> items = new List<StackPanel>();
                foreach (StackPanel item in mylb.Items)
                {
                    items.Add(item);
                }
                if (but.Tag == "up")
                {
                    if (index != 0)
                    {
                        StackPanel temp = items[index - 1];
                        items[index - 1] = items[index];
                        items[index] = temp;
                    }
                }
                else
                {
                    if (index != items.Count)
                    {
                        StackPanel temp = items[index + 1];
                        items[index + 1] = items[index];
                        items[index] = temp;
                    }
                }
                mylb.Items.Clear();
                foreach (StackPanel item in items)
                {
                    mylb.Items.Add(item);
                }
            }
        }
    }
