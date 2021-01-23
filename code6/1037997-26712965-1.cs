    DataTable DT = DS.Tables[0].Clone();
    DT.TableName = "temp";
    DS.Tables.Add(DT);
    query.CopyToDataTable(DT, LoadOption.OverwriteChanges);
    DGV.DataSource = DT; 
