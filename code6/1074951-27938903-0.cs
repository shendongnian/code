     //create columns as textbox columns(or whatever you want)
                DataGridViewTextBoxColumn dgc = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn dgc1 = new DataGridViewTextBoxColumn();
    
                //add the colums to the table
                dataGridView1.Columns.Add(dgc);
                dataGridView1.Columns.Add(dgc1);
                //set header text here if you wish
    
                //create dgv combobox cells and add items to the collection
                DataGridViewComboBoxCell cbc = new DataGridViewComboBoxCell();
                cbc.Items.Add("item 1");
                cbc.Items.Add("item 2");
                DataGridViewComboBoxCell cbc1 = new DataGridViewComboBoxCell();
                cbc1.Items.Add("item 1");
                cbc1.Items.Add("item 2");
    
                //create 2 rows here so that you can insert future columns without having them go above your comboboxes
                dataGridView1.Rows.Add(2);
    
                //set row one cells to combobox cells
                dataGridView1.Rows[0].Cells[0] = cbc;
                dataGridView1.Rows[0].Cells[1] = cbc1;
