    int i =0;
          for(i = 0; DsNow.Tables[0].Rows.Count - 1; i ++)
                {
                      ExcelAp.Cells[i + 6, 1] = DsNow.Tables[0].Rows[0]["name"].ToString();
                      ExcelAp.Cells[i + 6, 2] = DsNow.Tables[0].Rows[0]["address"].ToString();
                      ExcelAp.Cells[i + 6, 3] = DsNow.Tables[0].Rows[0]["contactnumber"].ToString(); 
                }
