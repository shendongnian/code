    int c = 0;
    OdbcConnection cn = openOdbcDB();
    foreach(DataSet ds in allDataSets)
    {
        foreach(DataTable dt in ds.Tables)
        {
            foreach (DataRow dr in dt.Rows)
            {
               insertIntoDatabaseCurrentRecord(dr);
               Application.DoEvents(); //Quick and dirty
            }
         }
         pbMain.Value = pbMain.Value + (33 / totalFiles);
         c++;
    }
    cn.Close();
    cn.Dispose();
