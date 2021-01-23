    DataTable currentAttribs = //return dataTable of results;    
    foreach (DataRow r in currentAttribs.Rows)
     {
        foreach (DataColumn column in currentAttribs.Columns)
           {
             //run through dataRow and access header?????
             {
                  tableRow = "<TR><TD>" + column.ColumnName + "</TD></TR>";
                  Literal lc = new Literal();
                  lc.Text = tableRow;
                  divFeatureInfo.Controls.Add(lc);
              }
           }
      }
