    public bool UserNameCheck()
    {
        bool IsUserExist = false;
        string constring = "Data Source=LFC;Initial Catalog=contactmgmt;Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand("Select count(*) from cntc_employee where emp_alias= @alias", con);
        cmd.Parameters.AddWithValue("@alias", this.textBox3.Text);
        con.Open();
       
        if(Convert.ToInt32(cmd.ExecuteScalar()) > 0)
        {            
               MessageBox.Show("Alias "+ dr[1].ToString() +" Already exist");
               return true;
        }
        else
        {
          return false;
        }
    }
