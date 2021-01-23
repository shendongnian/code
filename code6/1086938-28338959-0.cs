    var connStr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
   	using (var cmdconn = new SqlConnection(connStr)) 
	using (var cmd = new SqlCommand())
	{
		cmd.Connection = cmdconn;
		var conditions = new List<string>();
		if (!string.IsNullOrEmpty(cmbDivision.Text))
		{
			conditions.Add("b.DivisionCode like @Division");
			cmd.Parameters.AddWithValue("@Division", cmbDivision.Text + '%');
		}
		if (!string.IsNullOrEmpty(tbEnduser.Text))
		{
			conditions.Add("c.Enduser like @Enduser");
			cmd.Parameters.AddWithValue("@Enduser", tbEnduser.Text + '%');
		}
        var sql = @"select a.*, c.Enduser          
                  from matt.ServiceInfo a
                  left join matt.Divisions b on a.DivisionCode = b.DivisionCode
                  left join matt.EmployeeInfo c on a.DivisionCode = c.DivisionCode
                  where " + string.Join(" and ", conditions);
		
		cmd.CommandText = sql;
		SqlDataAdapter da = new SqlDataAdapter();
     	da.SelectCommand = cmd;
    	DataTable dt = new DataTable();
     	btnEdit.Visible = true;
    	da.Fill(dt);
     	dgvRptView.DataSource = dt;
    }
