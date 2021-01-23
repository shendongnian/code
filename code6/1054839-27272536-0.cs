    DataSet ds = new DataSet();
    ds.ReadXml(@"C:\demo.xml");
       if (ds.Tables.Count > 0)
    { 
         for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
         {
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
              {
                listBox1.Items.Add(ds.Tables[0].Rows[i][j].ToString());
              }
         }
    }
