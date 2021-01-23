       public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainViewModel();
                PlannerItemControl.ItemsSource = new List<string>() {"a", "b", "c"};
    
            }
    
    
    
            public static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            return (T)child;
                        }
    
                        T childItem = FindVisualChild<T>(child);
                        if (childItem != null) return childItem;
                    }
                }
                return null;
            }    
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                foreach (var item in PlannerItemControl.Items)
                {
                    ContentPresenter cp = PlannerItemControl.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter;
                    TextBox tb = FindVisualChild<TextBox>(cp);
                    if (tb != null)
                    {
                        tb.Text = item.ToString();
                        // do something with the textbox
                    }
                }
            }
        }
