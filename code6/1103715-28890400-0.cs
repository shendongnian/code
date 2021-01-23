    void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
      txtCCs.Text = String.Empty;
      foreach (DataGridViewRow row in dataGridView1.Rows) {
        if (Convert.ToBoolean(row.Cells[CC.Name].Value) == true) {
          txtCCs.Text += row.Cells[3].Value.ToString().Trim() + ", ";
        }
      }
    }
