    DataGrid myDataGrid;
    private void operationGrid_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
    {
        OperCountUnit _con = (OperCountUnit)e.Row.DataContext;
        myDataGrid = e.DetailsElement.FindName("sumOperationGrid") as DataGrid;
        //do stuff without passing grid
    }
    
    private void GetCurrencySumByCurrentItemCallBack(IAsyncResult result)
    {
        List<CurrencySum> sum = client.EndGetCurrencySumByCurrentitem(result).ToList<CurrencySum>();
        if (sum != null)
        {
            myDataGrid.Dispatcher.BeginInvoke(new Action(()=>
             {
                 myDataGrid.ItemSource = sum;
             });
    }
 
