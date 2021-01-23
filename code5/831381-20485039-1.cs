    if (GetDialogResult == DialogResult.No)
    {
        listView1.ItemSelectionChanged -= SelectionChanged;
        e.Item.Selected = false;
        listView1.ItemSelectionChanged += SelectionChanged;
    }
