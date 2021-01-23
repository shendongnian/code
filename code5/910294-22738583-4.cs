    DataTable dt = new DataTable();
    using(SqlConnection conn = new SqlConnection("server=.;uid=sa;pwd=123;database=PharmacyDB;"))
    using(SqlCommand cmd = new SqlCommand("select UnitPrice from ProductDetails where prdctName like @param"))
    {
       cmd.Connection = conn;
       cmd.Parameter.AddWithValue("@param", "%" + txtSelectedName.Text + "%");
       using(SqlDataAdapter da = new SqlDataAdapter(cmd, conn))
       {
           da.Fill(dt);
           DataRow dr = dt.NewRow();
           dr["UnitPrice"] = txtSelectedName.Text;
           dt.Rows.Add(dr);
           dt.Rows.Add(dr);
           dgvSelectedItem.DataSource = dt;
       }
    }
