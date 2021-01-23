    private void AddClassCombobox()
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "New Class";
            cmb.Name = "cmb";
            cmb.DataPropertyName = "Class";  // << Added this
            foreach (DataGridViewRow row in dgClasses.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    cmb.Items.Add(row.Cells[0].Value);
                }
            }
            dgProducts.Columns.Add(cmb);
        }
