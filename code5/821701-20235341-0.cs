    class Details
    {
    public string Name{get;set;}
    public string Age{get;set;}
    }
    ObservableCollection<Details> tempcollection{get;set;}
    private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
            {
                DataGrid dg = sender as DataGrid;
                gridIndex = dg.SelectedIndex;
            }
