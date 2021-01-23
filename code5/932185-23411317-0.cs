    public partial class FilteringSample : Window
    {
                public FilteringSample()
                {
                        InitializeComponent();
                        List<Word> items = new List<Word>();
                        items.Add(new User() { Name = "Apple"});
                        items.Add(new User() { Name = "Orange"});
                        items.Add(new User() { Name = "Pineapple" });
                        items.Add(new User() { Name = "Define",});
                        lvDictionary.ItemsSource = items;
                        CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvDictionary.ItemsSource);
                        view.Filter = UserFilter;
                }
                private bool UserFilter(object item)
                {
                        if(String.IsNullOrEmpty(txtFilter.Text))
                                return true;
                        else
                                return ((item as Word).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
                {
                 CollectionViewSource.GetDefaultView(lvDictionary.ItemsSource).Refresh();
                }
    }
