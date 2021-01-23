            private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Now we can get Column like this.
            var column = dataGrid.GetColumnByIndices(1, 1);
            //As SO want to find the ComboBox within that Column 
            ComboBox comboBox;
            var cell = dataGrid.GetCellByIndices(1, 1); //DataGridColumn Does'nt Inherit Visual class so using GetCellByIndices
            
            if(cell!=null)
                comboBox = cell.GetVisualChild<ComboBox>(); //DataGridCell Inherit Visual so we can use our VisualHelper Method
        }
