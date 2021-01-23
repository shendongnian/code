    void OnCopying(object sender, DataGridCellClipboardEventArgs args)
    { 
        if (args.Column == comboColumn && args.Item as ComboBox<float> != null)
            args.Content = ((ComboBox<float>)args.Item).Key;
    }
