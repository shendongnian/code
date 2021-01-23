    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        ((TextBox)e.EditingElement).Text = 
            ConvertToHexadecimal(((TextBox)e.EditingElement).Text);
    }
    private string ConvertToHexadecimal(string input)
    {
        int number = 0;
        bool isInputInteger = int.TryParse(input, out number); 
        return isInputInteger ? number.ToString("X") : input; 
    }
