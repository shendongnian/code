    var dt = new DataTable();
    //create columns
    for(int i = 1; i <= 12; i++){
        dt.Columns.Add(new DataColumn(i.ToString(CultureInfo.InvariantCulture), typeof(string)));
    }
    //create rows
    for(int i = 0; i < 8; i++){
        var newRow = dt.NewRow();
        for(int j = 1; j <= 12; j++){
            newRow[j.ToString(CultureInfo.InvariantCulture)] = string.Empty;
        }
        dt.Rows.Add(newRow);
    }
    myGridView.DataSource = dt;
    myGridView.DataBind();
