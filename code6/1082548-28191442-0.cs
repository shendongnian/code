        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = GetDataSet();
            this.dataGridView1.DataMember = "Students";
            this.dataGridView1.Columns.Add("unboundColumn1", "ID");
            this.dataGridView1.Columns.Add("unboundColumn2", "Name");
            this.dataGridView1.Columns["unboundColumn1"].Visible = false;
            this.dataGridView1.Columns["unboundColumn2"].Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns["unboundColumn1"].Visible = true;
            this.dataGridView1.Columns["unboundColumn2"].Visible = true;
            this.dataGridView1.DataSource = null;
        }
        private DataSet GetDataSet()
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add("Students");
            dataSet.Tables["Students"].Columns.Add("ID", typeof(int));
            dataSet.Tables["Students"].Columns.Add("Name", typeof(string));
            dataSet.Tables["Students"].Rows.Add(1, "John Joy");
            dataSet.Tables["Students"].Rows.Add(2, "Ivan Nova");
            dataSet.Tables["Students"].Rows.Add(3, "Michael German");
            return dataSet;
        }
