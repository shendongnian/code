        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs eventArgs)
        {
            if (sender == null) return;
            if (eventArgs.ButtonState != MouseButtonState.Pressed) return; //only react on pressed
            var dataGrid = sender as DataGrid;
            if (dataGrid == null || dataGrid.SelectedItems == null) return;
            if (dataGrid.SelectedItems.Count == 1)
            {
                var simplePension = dataGrid.SelectedItem as ISimplePension;
                if (simplePension != null)
                {
                    DataFetcherHolder.DataFetcher.SelectPension(simplePension);
                    Execute(EditSelectedPensionFunction);
                }
            }
        }
