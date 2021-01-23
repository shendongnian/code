    public class CustomComparer : IComparer
    {
        public bool Ascending { get; private set; }
        public string Field { get; private set; }
        public CustomComparer(string fieldName, bool ascending)
        {
            this.Ascending = ascending;
            this.Field = fieldName;
        }
        public int Compare(object x, object y)
        {
            // Ideally check for identical types/etc and IComparable here
            PropertyInfo property = x.GetType().GetProperty(this.Field);
            IComparable val1 = property.GetValue(x) as IComparable;
            IComparable val2 = property.GetValue(y) as IComparable;
            return val1.CompareTo(val2) * (this.Ascending ? 1 : -1);
        }
    }
    private void DataGrid_OnSorting(object sender, DataGridSortingEventArgs e)
    {
        ListCollectionView dataView = (ListCollectionView)CollectionViewSource.GetDefaultView(((DataGrid)sender).ItemsSource);
            
        // Assumes the column header is identical to field name
        bool ascending = true;
        string fieldName = e.Column.Header.ToString();
        // Check to see if we're reversing the sort
        CustomComparer comparer = dataView.CustomSort as CustomComparer;
        if (comparer != null && comparer.Field == fieldName)
            ascending = !comparer.Ascending;
        e.Column.SortDirection = ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
        dataView.CustomSort = new CustomComparer(fieldName, ascending);
        dataView.Refresh();
        e.Handled = true;
    }
