    private void gridView1_ShownEditor(object sender, EventArgs e)
    {
        if (gridView1.FocusedColumn.FieldName != "YourColumnName")
            return;
        var editor = (CheckedComboBoxEdit)gridView1.ActiveEditor;
        editor.Properties.Items.Clear();
        if (gridView1.FocusedRowHandle == 0)
            editor.Properties.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem("a"), new CheckedListBoxItem("b") });
        else
            editor.Properties.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem("b"), new CheckedListBoxItem("c"), new CheckedListBoxItem("d") });
    }
