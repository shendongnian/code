    void Button_Click(Object sender, EventArgs e)
    {
        // If the cell wasn't set, return
        if (activatedCell == null) { return; }
        // Set the number to your buttons' "Tag"-property, and read it to Cell
        if (activatedCell.Value != null) { activatedCell.Value = Convert.ToDouble(((Button)sender).Tag) + Convert.ToDouble(activatedCell.Value);
        else { activatedCell.Value = Convert.ToDouble(((Button)sender).Tag); }
        dataGridView1.Refresh();
        dataGridView1.Invalidate();
        dataGridView1.ClearSelection();
    }
