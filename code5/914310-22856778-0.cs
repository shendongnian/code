            dgv_TraceItems.AutoGenerateColumns = false;
            dgv_TraceItems.Columns.Add(CreateComboBoxWithEnums());
            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "number";
            column.Name = "number";
            dataGridView1.Columns.Add(column);
            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "file";
            column.Name = "file";
            dataGridView1.Columns.Add(column);
            // Initialize and add a check box column.
            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "isselected";
            column.Name = "isselected";
            dataGridView1.Columns.Add(column);
             
            // Initialize the form. 
            this.Controls.Add(dataGridView1);
            this.AutoSize = true;
            List<myClass> bindingData = new List<myClass>();
            for (int i = 0; i < 5; i++)
            {
                myClass testObj = new myClass();
                testObj.File = "test" + i;
                testObj.IsSelected = true;
                testObj.Type = TYPE.high;
                bindingData.Add(testObj);
            }
            dgv_TraceItems.DataSource = bindingData;
        }
        DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
        DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
        combo.DataSource = Enum.GetValues(typeof(TYPE));
        combo.DataPropertyName = "Type";
        combo.Name = "Type";
        return combo;
        }
