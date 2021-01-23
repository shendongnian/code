    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is TextBox)
        {
            ((TextBox)e.Control).TextChanged += TextBoxCell_TextChanged;
        }
    }
