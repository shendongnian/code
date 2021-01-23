     void matchColumn()
      {
        SqlDataAdapter da = new SqlDataAdapter("select * from images", "connectionString");
     
        DataTable DataTableA = new DataTable();
        da.Fill(DataTableA); // Fill the dataset
     
        SqlDataAdapter da2 = new SqlDataAdapter("select * from images", "connectionString");
     
        DataTable DataTableb = new DataTable();
        da.Fill(DataTableb); // Fill the dataset2
        int found = 0;
        for (int i = 0; i < DataTableA.Rows.Count; i++)
        {
          if (DataTableB.Rows[i][0] == DataTableA.Rows[i][0] && DataTableB.Rows[i][1] == DataTableA.Rows[i][1])
          {
            DataTableB.Rows[i]["Country"] = "Matched";
            found++;
     
            if (found >= 2)
            {
              //perform insertion
            }
          }
          else
          {
            DataTableB.Rows[i]["Country"] = "Not Matched";
          }
        }
         
      }
