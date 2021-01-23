        string constr = "Data Source =. ;Initial Catalog =reg ;Integrated Security=true;";
        SqlConnection conn = new SqlConnection(constr);
        try
        {
            conn.Open();
        }
        catch (Exception err)
        { MessageBox.Show(err.Message); }
        string sql = "Insert Into Course(CustomerFName,CustomerLName,Email,PhoneNo,CourseName) Values(@CustomerFName,@CustomerLName,@Email,@PhoneNo,@CourseName)";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@CustomerFName", txthrfn.Text);
        cmd.Parameters.AddWithValue("@CustomerLName", txthrln.Text);
        cmd.Parameters.AddWithValue("@Email", txthrem.Text);
        cmd.Parameters.AddWithValue("@PhoneNo", txthrmob.Text);
        cmd.Parameters.AddWithValue("@CourseName", ddlhr.SelectedItem.ToString());
        
        try { cmd.ExecuteNonQuery(); }
        catch (Exception err)
        { MessageBox.Show(err.Message); }
        try { conn.Close(); }
        catch (Exception err)
        { MessageBox.Show(err.Message); }
