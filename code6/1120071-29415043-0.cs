    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
      //search for identical value
      if (row.Cells[0].Value.ToString().Equals(searchValue))//searchvalue would be set using ComboBox.Text
      {
        dataGridView1.Rows[0].Visible = true;
      }
      //search for first art that contains search value
      else
      {
        dataGridView1.Rows[0].Visible = false;
      }
    }
