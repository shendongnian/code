    list1.AddRange(
        dataGridView1.Rows
                     .Cast<DataGridViewRow>()
                     .Select(x => new ClsOBJ
                                      {
                                        userid = Convert.ToInt32(x.Cells[0].Value),
                                        username = Convert.ToString(x.Cells[1].Value)
                                      }));
