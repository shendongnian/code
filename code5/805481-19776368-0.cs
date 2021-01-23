        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            string cell = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["CellName"].Value.ToString();
            if (!string.IsNullOrEmpty(cell))
                Clipboard.SetText(cell);
        }
