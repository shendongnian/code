            string id = dt.Rows[e.RowIndex]["Eid"] + "";
            string col = dt.Columns[e.ColumnIndex].ColumnName;
            string data = dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "";
            string sql = string.Format("UPDATE `test`.`edata` SET `{0}` = '{1}' WHERE Eid = {2};", col, data, id);
            using (MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=123"))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
> 
        private void Form4_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=123"))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select *from test.edata ;";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                conn.Close();
            }
            dgv1 = new DataGridView();
            dgv1.AllowUserToAddRows = true;
            dgv1.CellEndEdit += new DataGridViewCellEventHandler(dgv_CellEndEdit);
            dgv1.CellValidating += new DataGridViewCellValidatingEventHandler(dgv_CellValidating);
            dgv1.Dock = DockStyle.Fill;
            dgv1.DataSource = dt;
            this.Controls.Add(dgv1);
        }
    }
        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            InitializeComponent();
            if (e.ColumnIndex == 0)
            {
                dgv1.CancelEdit();
            }
        }
