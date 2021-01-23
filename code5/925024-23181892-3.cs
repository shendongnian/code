    for(int i=0; i<posCount; i++)
    {
        DataGridView dgv
            = new DataGridView
              {
                  Name = dataGridView.Name,
                  DataSource = dataGridView.DataSource,
                  ...
              };
        dataGridViewList.Add(dgv);
    }
