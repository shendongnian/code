    private void gridView1_ShownEditor(object sender, EventArgs e)
    {
        if (gridView1.FocusedColumn.FieldName != "YourCheckedComboBoxColumn")
            return;
        var editor = (CheckedComboBoxEdit)gridView1.ActiveEditor;
        editor.Properties.Items.Clear();
        var value = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "YourEyeColumn").ToString();
        if (value == "Eye Color")
            editor.Properties.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem("Green"), new CheckedListBoxItem("Blue"), new CheckedListBoxItem("Grey") });
        else if (value == "Eye Size")
            editor.Properties.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem("Big"), new CheckedListBoxItem("Medium"), new CheckedListBoxItem("Small") });
    }
