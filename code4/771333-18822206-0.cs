    SqlConnection CN = new SqlConnection(mysql.CON.ConnectionString);
    dataGridView1.AutoGenerateColumns = false;
    DataTable dt = new DataTable();
    SqlDataAdapter sda = new SqlDataAdapter("select id,name,age,notes  from test where id = '" + txtID.Text + "'", CN);
    sda.Fill(dt);
    dataGridView1.DataSource = dt;
