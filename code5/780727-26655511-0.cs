        private void Form1_Load(object sender, EventArgs e)
    {
        dt = new DataTable();
        using (MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=1234"))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "select *from try.data ;";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            conn.Close();
        }
        dgv1 = new DataGridView();
        dgv1.AllowUserToAddRows = false;
        dgv1.CellEndEdit += new DataGridViewCellEventHandler(dgv_CellEndEdit);
        dgv1.CellValidating += new DataGridViewCellValidatingEventHandler(dgv_CellValidating);
        dgv1.Dock = DockStyle.Fill;
        dgv1.DataSource = dt;
        this.Controls.Add(dgv1);
    }
