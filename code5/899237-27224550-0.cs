    public string populateLookUp(ref System.Windows.Forms.ComboBox Combo, string Id)
    {
        SqlCommand _comm = new SqlCommand();
        _comm.Parameters.AddWithValue("@id", Id);
        _comm.CommandText = "SELECT [name] FROM dbo.fnGetName(@id) ORDER BY [name]; ";   
        _comm.Connection = _conn;
        _comm.CommandTimeout = _command_timeout;
        DataTable dt = new DataTable();
        try
        {
            SqlDataReader myReader = _comm.ExecuteReader();
            dt.Load(myReader);
        }
        catch
        {
            MessageBox.Show("Unable to populate Name LookUp");
        }
        Combo.DataSource = dt;            
        Combo.DisplayMember = "name";
        Combo.ValueMember = "name";
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["company_int_name"].ToString() == Contract.Company_trans_Selling_Entity.ToString())
            {
                Combo.SelectedValue = dr["company_int_name"].ToString();
            }
        }
        return "";
    }
