    private void textbox_PreviewDrop(object sender, DragEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string name = e.Data.GetData(DataFormats.StringFormat).ToString();
        textBox.Text += name;
        textBox.Focus();
        textBox.CaretIndex = textBox.Text.Length;
        e.Handled = true;
        bool remove = _UsersList.Remove((User)listbox1.SelectedItem);
    }
