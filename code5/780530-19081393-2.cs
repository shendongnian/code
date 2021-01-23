     listmy = new ObservableCollection<TreeViewCustomItem> { new TreeViewCustomItem { Header = "xD" }, new TreeViewCustomItem { Header = "xxD" } };
            //treeView1.ItemsSource = listmy;
            this.DataContext = listmy;
     public class selector : DataTemplateSelector
    {
        public DataTemplate RegulationTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            TreeViewCustomItem treeViewItem = item as TreeViewCustomItem;
            if (treeViewItem.Header == "xD")
            {
                return RegulationTemplate;
            }
            else
            {
                return DefaultTemplate;
            }
        }
    }
