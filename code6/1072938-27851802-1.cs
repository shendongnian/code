    List<DataGridViewComboBoxColumn> myColumns = new List<DataGridViewComboBoxColumn>();
    for(int i=0; i < (the number you want); i++)
    {
         DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
         combo.Name = "name_" + i;
         combo.HeaderText = "Name " + i;
    }
