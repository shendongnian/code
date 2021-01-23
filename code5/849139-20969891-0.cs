        _con.Open();
        SqlCommand _viewLandmarks = new SqlCommand("dbo.SelectDevices_AddingForm", _con);
        _viewDevices.CommandType = CommandType.StoredProcedure;
        _viewDevices.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(_viewLandmarks);
        DataTable dTable = new DataTable("LANDMARK");
        da.Fill(dTable);
        DataRow fakeRow = dTable.NewRow();
        fakeRow["Landmark"] = "(ALL)";
        fakeRow["LandmarkID"] = -1;
        dTable.Rows.Add(fakeRow);
  
        comboModel.DataSource = dTable;
        comboModel.DisplayMember = "Landmark";
        comboModel.ValueMember = "LandmarkID";
        _con.Close();
