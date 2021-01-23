    DataTable dt1 = new DataTable(); 
    DataTable dt2 = new DataTable();
    DataRow[] dr1 = ds.Tables[0].Select("Column1 ='1234'");
    DataRow[] dr2 = ds.Tables[0].Select("Column1 ='1000'");
    dt1.Rows.Add(dr1);
    dt2.Rows.Add(dr2);
