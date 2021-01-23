    void OnDataGridSort(object sender, System.Windows.Controls.DataGridSortingEventArgs e)
    {
        DataGrid dg = sender as DataGrid;
        ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(dg.ItemsSource);
        lcv.CustomSort = [Your IComparer instance here];
        e.Handled;
    }
