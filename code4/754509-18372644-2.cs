    public class MyGridView : GridView
    {
        public ObservableCollection<object> BindableSelectedItems
        {
            get { return GetValue(BindableSelectedItemsProperty) as ObservableCollection<object>; }
            set { SetValue(BindableSelectedItemsProperty, value as ObservableCollection<object>); }
        }
        public static readonly DependencyProperty BindableSelectedItemsProperty =
            DependencyProperty.Register("BindableSelectedItems",
            typeof(ObservableCollection<object>), typeof(MyGridView),
            new PropertyMetadata(null, (s, e) =>
            {
                (s as MyGridView).SelectionChanged -= (s as MyGridView).MyGridView_SelectionChanged;
                (s as MyGridView).SelectionChanged += (s as MyGridView).MyGridView_SelectionChanged;
            }));
        void MyGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BindableSelectedItems == null)
                return;
            foreach (var item in BindableSelectedItems.Where(x => !this.SelectedItems.Contains(x)).ToArray())
                BindableSelectedItems.Remove(item);
            foreach (var item in this.SelectedItems.Where(x => !BindableSelectedItems.Contains(x)))
                BindableSelectedItems.Add(item);
        }
    }
