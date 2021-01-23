            DataTable machineComboList = new DataTable();
            machineComboList.Columns.Add("Value", typeof(string));
            DataColumn machineIdColumn = machineComboList.Columns.Add("Key", typeof(int));
            machineIdColumn.AllowDBNull = true;
            foreach (EMDataSet1.MachinesRow machineRow in this.eMDataSet1.Machines)
            {
                DataRow comboBoxDataRow = machineComboList.NewRow();
                comboBoxDataRow["Value"] = machineRow.Description;
                comboBoxDataRow["Key"] = machineRow.MachineID;
                machineComboList.Rows.Add(comboBoxDataRow);
            }
            DataRow nullComboBoxDataRow = machineComboList.NewRow();
            nullComboBoxDataRow["Value"] = "All";
            nullComboBoxDataRow["Key"] = DBNull.Value;
            machineComboList.Rows.Add(nullComboBoxDataRow);
            dataGridViewComboMachineID.DataSource = machineComboList;
            dataGridViewComboMachineID.DisplayMember = "Value";
            dataGridViewComboMachineID.ValueMember = "Key";
