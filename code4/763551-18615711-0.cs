    for (int i = 0; i < dgResults.Items.Count; i++)
    {
        var x = dgResults.GetCell(i, 0).Content as System.Windows.Controls.ComboBox;
    
        var list = x.ItemsSource as List<string>;
        x.SelectedItem =list.Where(s => s =="One of the items of my array").FirstorDefault();
    }
 
