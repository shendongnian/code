    for(int i=0; i < (the number you want); i++)
    {
         dataGridView1.Columns.Insert(i, new DataGridViewComboBoxColumn{
                                          Name = "name_" + i,
                                          HeaderText = "Name " + i});
    }
