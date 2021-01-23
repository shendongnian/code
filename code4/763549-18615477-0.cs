    for (int i = 0; i < dgResults.Items.Count; i++)
    {
        var x = dgResults.GetCell(i, 0).Content as System.Windows.Controls.ComboBox;
        x.SelectedIndex = dgResults.Items.Count - 1;
    }
