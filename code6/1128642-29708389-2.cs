    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (dataGridView1.EditingControl == null)
        {
            dataGridView1.BeginEdit(false);
            TextBox editor = (TextBox)dataGridView1.EditingControl;
            // insert checks for null here if needed!!
            int ms = editor.GetCharIndexFromPosition(e.Location);
            editor.SelectionStart = ms;
            editor.SelectionLength = Math.Min(3, editor.Text.Length - editor.SelectionStart);
        }
    }
