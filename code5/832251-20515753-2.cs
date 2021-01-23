    SqlConnection conn = new SqlConnection("Data Source=jaci;Initial Catalog=projecttest;Integrated Security=True");
    string query = string.Format("SELECT name_of_course FROM course WHERE kathedra='" + comboBox1.Text + "' AND year='" + comboBox2.Text + "'");
    SqlCommand cmd = new SqlCommand(query);
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
    adapter.Fill(dt);
    ds.Tables.Add(dt);
                
    foreach (DataRow dr in dt.Rows)
    {
        comboBox3.Items.Add(dr[0].ToString());
    }
