    Dim comboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
    comboBoxColumn.HeaderText = "Location"
    comboBoxColumn.DataPropertyName = "Location"
    comboBoxColumn.DataSource = dtLocations
    comboBoxColumn.ValueMember = dtLocations.Columns(0).ColumnName
    comboBoxColumn.DisplayMember = dtLocations.Columns(1).ColumnName
    dgvPickList.Columns.RemoveAt(1)
    dgvPickList.Columns.Insert(1, comboBoxColumn)
