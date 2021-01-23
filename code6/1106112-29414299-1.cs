    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if ((e.State & DataGridViewElementStates.Selected) != 0)
        {
            e.CellStyle.SelectionBackColor = Color.Pink;
        }
    }
