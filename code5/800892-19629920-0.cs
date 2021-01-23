            for( int i = 0 ;i< dt.Rows.Count; i++)
            {
               If(dt.Rows[i].Product_id == 2)
               {
                  dt.Rows[i].Columns["Product_name"].ColumnName = "cde";
               }
            }
