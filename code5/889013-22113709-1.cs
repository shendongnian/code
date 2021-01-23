    protected void btnreg_Click(object sender, EventArgs e)
        {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\19-02\ABCC\App_Data\abcc.mdf;Integrated Security=True;User Instance=True");
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM recipe WHERE  nor LIKE '%" + query.Text + "%' OR recipe LIKE '%" + query.Text + "%'  OR ingredients LIKE '%" + query.Text + "%'  OR type_of_food LIKE '%" + query.Text + "%' OR type_of_meal LIKE '%" + query.Text + "%' ", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        repeter.DataSource = dt;
        repeter.DataBind();
    }
