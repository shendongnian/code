        private void operationGrid_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            OperCountUnit _con = (OperCountUnit)e.Row.DataContext;
            client.BeginGetCurrencySumByCurrentItem((int)_con.Id, new AsyncCallback(GetCurrencySumByCurrentItemCallBack), null);
        }        
        private delegate void CurrencySumByCurrentItemInvoke(List<CurrencySum> sum);
        private void GetCurrencySumByCurrentItemCallBack(IAsyncResult result)
        {
            List<CurrencySum> sum = client.EndGetCurrencySumByCurrentItem(result).ToList<CurrencySum>();
            if (sum != null)
            {
                Dispatcher.Invoke(new CurrencySumByCurrentItemInvoke(GetCurrencySumByCurrentItemInvoke), new object[1] { sum });
            }        
        }
        void GetCurrencySumByCurrentItemInvoke(List<CurrencySum> sum)
        {
            DataGridRow opGrRow = (DataGridRow)(this.operationGrid.ItemContainerGenerator.ContainerFromItem(this.operationGrid.SelectedItem));
            DataGridDetailsPresenter cpOpGrRow = FindVisualChild<DataGridDetailsPresenter>(opGrRow);
            DataTemplate dtOpGrRow = cpOpGrRow.ContentTemplate;
            DataGrid s2 = (DataGrid)dtOpGrRow.FindName("sumOperationGrid", cpOpGrRow);
            s2.ItemsSource = sum;
        }
