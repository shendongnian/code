    for (int i = 0; i < dgResults.Items.Count; i++)
    {
        var x = dgResults.GetCell(i, 0).Content as System.Windows.Controls.ComboBox;
        var array = x.ItemsSource as string[] ;
        x.SelectedItem = array.Where(s => s == "B").FirstOrDefault();
    }
