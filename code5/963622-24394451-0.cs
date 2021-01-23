     private void GridFilterForm_Load(object sender, EventArgs e)
        {
            this.InitializeGrid();
        }
        private DataView dataView;
        private void InitializeGrid()
        {
            DataTable dataTable = new DataTable();  
            dataView = new DataView(dataTable);
            
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Rows.Add("1", "Name1");
            dataTable.Rows.Add("2", "Name2");
            dataTable.Rows.Add("3", "Name3");
            dataTable.Rows.Add("4", "Name4");
            
            //Bind to dataView
            this.dataGridView1.DataSource = dataView;
            //make sure about the datatable to show all
            this.comboBox1.DataSource = dataTable;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue !=null)
            {
                //Filter the DataView
                string value=   this.comboBox1.SelectedValue as string;
                if (!string.IsNullOrEmpty(value))
                {
                    //filter on id
                    dataView.RowFilter = "Id = " + value;
                }
            }
            else
            {
                dataView.RowFilter = null;
            }
        }
