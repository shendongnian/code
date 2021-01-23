    private void dataGridView1_Sorted(object sender, EventArgs e)
    {
      this.LockBottomRow();
    }
    private void LockBottomRow()
    {
      foreach (DataGridViewRow row in this.dataGridView1.Rows)
      {
        if (row.Tag != null && row.Tag.ToString() == "Totals")
        {
          int index = this.dataGridView1.Rows.Count - 2;
          this.dataGridView1.Rows.Remove(row);
          this.dataGridView1.Rows.Insert(index, row);
        }
      }
    }
