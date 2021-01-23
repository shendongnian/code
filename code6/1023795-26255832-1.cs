    private void filldropdown()
        {
            SqlCommand cmd = new SqlCommand("Select EmpID from Tbl_Emp", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            TextBox3.Items.Clear();
            if (dr.HasRows)
            {
    
                while (dr.Read())
                {
                    TextBox3.Items.Add(dr["EmpID"].ToString());
                }
            }
            con.Close();
    	dr.Close
        }
    
    
    
    
    
    protected void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Emp where EmpID=@id", con);
            cmd.Parameters.AddWithValue("@id", TextBox3.Text);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows && dr.Read())
            {
                TextBox1.Text = dr["EmpID"].ToString();
                TextBox2.Text = dr["EmpName"].ToString();
                Image1.ImageUrl = "Handler.ashx?EmpID=" + TextBox3.Text;
            }
            else
            {
                Response.Write("Record With This ID Note Found");
            }
    	dr.Close();
        }
