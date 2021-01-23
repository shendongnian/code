    public void btnSearch_Click(object sender, EventArgs e)
    {
		if (string.IsNullOrEmpty(tbEnduser.Text) && string.IsNullOrEmpty(cmbDivision.Text))
		{
			MessageBox.Show("Please fill the following fields");
			return;
		}
        using (var cmdconn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString)) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cmdconn;
			string text = @"select a.*, c.Enduser          
                            from matt.ServiceInfo a
                            left join matt.Divisions b
                            on
                            a.DivisionCode = b.DivisionCode
                            left join matt.EmployeeInfo c
                            on a.DivisionCode = c.DivisionCode";
			if (!string.IsNullOrEmpty(tbEnduser.Text) &
                    (!string.IsNullOrEmpty(cmbDivision.Text)))
            {
                text += " where b.DivisionCode like @Division and c.Enduser like @Enduser";
                cmd.Parameters.AddWithValue("@Enduser", tbEnduser.Text + '%');
                cmd.Parameters.AddWithValue("@cmbDivison", cmbDivision.Text + '%');
                btnEdit.Visible = true;
            }
            else if (!string.IsNullOrEmpty(cmbDivision.Text) &
                (string.IsNullOrEmpty(tbEnduser.Text)))
            {
                text += " where b.DivisionCode like @Division";
                cmd.Parameters.AddWithValue("@Division", cmbDivision.Text + '%');
            }
            else if (!string.IsNullOrEmpty(tbEnduser.Text) &
                    (string.IsNullOrEmpty(cmbDivision.Text)))
            {
                text+=" where c.Enduser like @Enduser";
                cmd.Parameters.AddWithValue("@Enduser", tbEnduser.Text + '%');
            }
            
            cmd.CommandText = text;
			SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRptView.DataSource = dt;
        }
    }
