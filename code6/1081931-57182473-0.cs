    private static bool CanEditCell(DataGridCell cell)
    {
        if (!(cell.Column is DataGridTemplateColumn col)) return false; //TemplateColumns only    
        //dont process noneditable or already editing cell
        return !(cell.IsEditing || cell.IsReadOnly); 
    }
    
    private static void DataGrid_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        //ignore non-key input related events, e.g. ctrl+c/ctrl+v
        if (string.IsNullOrEmpty(e.Text)) return;
    
        if (e.Source is DataGrid dg &&
            e.OriginalSource is DataGridCell cell &&
            CanEditCell(cell))
        {
            dg.BeginEdit();
            //custom extension method, see
            var tb = cell.GetVisualChild<TextBox>();
            tb?.Focus(); //route current event into the input control
            tb?.SelectAll(); //overwrite contents
        }
    }
