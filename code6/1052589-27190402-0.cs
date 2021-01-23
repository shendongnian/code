    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int topIndex = sourceListBox.TopIndex;
        sourceListBox.SelectionMode = SelectionMode.One;
        if (textBox1.Text != string.Empty)
        {
            int index = sourceListBox.FindString(textBox1.Text);
            if (index != -1 && sourceListBox.SelectedIndex != index)
            {
                sourceListBox.ClearSelected();
                sourceListBox.SetSelected(index, true);
                topIndex = sourceListBox.SelectedIndex;
            }
        }
        else
        {
            sourceListBox.ClearSelected();
        }
        sourceListBox.SelectionMode = SelectionMode.MultiExtended;
        sourceListBox.TopIndex = topIndex;
    }
