    cbColumn = new DataGridViewComboBoxColumn();
    cbColumn.DataSource = listPlodiny;
    //add next two rows
    cbColumn.DisplayMember = "PLODINY.Description" //property from .Datasource you want to show for user
    cbColumn.ValueMember = "PLODINY.ID" //property from .Datasource you want use as Value - reference to DataPropertyName
    cbColumn.DropDownWidth = 100;
    dataGridView1.Columns.Add(cbColumn);
    cbColumn.DisplayIndex = 3;
    cbColumn.HeaderText = "Položka";
    cbColumn.DataPropertyName = "POLOZKAcb";
