    foreach (DataGridViewColumn column in dataGridView2.Columns)
    {
        checkedListBox1.Items.Add(column.HeaderText, column.Visible);
        checkedListBox1.ItemCheck += (ss, ee) =>
        {
            if (checkedListBox1.SelectedItem != null)
            {
                var selectedItem = checkedListBox1.SelectedItem.ToString();
                dataGridView2.Columns[selectedItem].Visible = ee.NewValue == CheckState.Checked;
            }
        };
    }
}
