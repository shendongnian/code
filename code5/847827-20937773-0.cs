        private void textbox1_PreviewDrop(object sender, DragEventArgs e)
        {
            MethodA(e, textbox1);
        }
        private void textbox2_PreviewDrop(object sender, DragEventArgs e)
        {
            MethodA(e, textbox2);
        }
        private void MethodA(DragEventArgs e, TextBox textbox)
        {
            string name = e.Data.GetData(DataFormats.StringFormat).ToString();
            textbox.Text += name;
            textbox.Focus();
            textbox.CaretIndex = textbox.Text.Length;
            e.Handled = true;
            bool remove = _UsersList.Remove((User)listbox1.SelectedItem);
        }
