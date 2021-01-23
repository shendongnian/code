    foreach (var person in persons)
    {
      var row = new DataGridViewRow();
      row.Cells.Add(new DataGridViewTextBoxCell());
      row.Cells.Add(new DataGridViewTextBoxCell());
      row.Cells.Add(new DataGridViewComboBoxCell());
      row.Cells[0].Value = person.Name;
      row.Cells[1].Value = Person.Age;
      var percolours = person.ColourList.Select(x => x.Color).ToList();
      ((DataGridViewComboBoxCell)row.Cells[1]).DataSource = percolours;
      dataGridView1.Rows.Add(row);
    }
