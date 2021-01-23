    DataTable DT = DS.Tables[0].Clone();
    DT.TableName = "temp";
    DS.Tables.Add(DT);
    DS.Tables["temp"].Rows.Clear();
    query.CopyToDataTable( DS.Tables["temp"], LoadOption.OverwriteChanges);
    DGV.DataSource = DS.Tables["temp"]; 
