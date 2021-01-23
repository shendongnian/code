    void SaveDataGridViewToCSV(string Filename)
    {
        dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
        dataGridView1.SelectAll();
        Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
        File.WriteAllText(Filename,Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
    }
