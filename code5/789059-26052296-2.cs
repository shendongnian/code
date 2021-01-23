    void SaveDataGridViewToCSV(string Filename)
    {
        // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
        dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
        // Select all the cells
        dataGridView1.SelectAll();
        // Copy (set clipboard)
        Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
        // Paste (get the clipboard and serialize it to a file)
        File.WriteAllText(Filename,Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
    }
