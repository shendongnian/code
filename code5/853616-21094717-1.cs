    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CbxItems.PreviewMouseRightButtonDown += OnPreviewMouseRightButtonDown;
        }
        private void OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var comboBoxItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);
            if (comboBoxItem == null) return;
            comboBoxItem.IsSelected = true;
            e.Handled = true;
        }
        private ComboBoxItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is ComboBoxItem))
                source = VisualTreeHelper.GetParent(source);
            return source as ComboBoxItem;
        }
        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            CbxItems.Items.Remove(CbxItems.SelectedItem);
        }
    }
