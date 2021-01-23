    const readonly string UserbuttonName = "Users";
    private void CreatebuttonName()
    {
      colUsers.Name = UserbuttonName;
    }
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
     if (e.RowIndex > -1 && dataGridView1.Columns[e.ColumnIndex].Name == UserbuttonName)
      DoSomething();
    }
