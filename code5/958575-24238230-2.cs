    public bool UserNameCheck()
    {        
        string constring = "Data Source=LFC;Initial Catalog=contactmgmt;Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("Select count(*) from cntc_employee where emp_alias= @alias", con);
        cmd.Parameters.AddWithValue("@alias", this.textBox3.Text);
        con.Open();
        int TotalRows = 0;
        TotalRows = Convert.ToInt32(cmd.ExecuteScalar());
        if(TotalRows > 0)
        {            
               MessageBox.Show("Alias "+ dr[1].ToString() +" Already exist");
               return true;
        }
        else
        {
               return false;
        }
    }
