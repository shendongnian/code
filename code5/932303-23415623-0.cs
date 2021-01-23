    protected void DropDownListDoctor_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = "SELECT * FROM Doctor WHERE Doc_Id=" + DropDownListDoctor.SelectedValue + "";
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        da.Fill(dt);
        GridViewDoctorDetail.DataSource = dt;
        GridViewDoctorDetail.DataBind();
    }
