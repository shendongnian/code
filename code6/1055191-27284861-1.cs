    private void btnAddInputToGrid_Click(object sender, EventArgs e)
    {
        // add the new row, get its index
        var newIndex = dataGridView1.Rows.Add(txtEmail.Text, txtPass.Text);
        // select just the new row
        dataGridView1.ClearSelection();
        dataGridView1.Rows[newIndex].Selected = true;
        // select the cell you're interested in and put it in edit mode
        dataGridView1.CurrentCell = dataGridView1.Rows[newIndex].Cells[0];
        dataGridView1.BeginEdit(false);
    }
