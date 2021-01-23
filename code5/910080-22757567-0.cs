     private void bind()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AttendanceManagmentSystem.Properties.Settings.Cons1"].ConnectionString);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select EmpId from EmpDetail", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "EmpId";
            comboBox1.ValueMember = "EmpId";
            comboBox1.DataSource = dt;
            con.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = comboBox1.Text;
        }
