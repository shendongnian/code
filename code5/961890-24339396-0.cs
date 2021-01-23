     if (gridView1.RowCount > 0)
     {
          if (gridView1.GetSelectedRows().Count() > 0) //optional check
          {
              string tblItemCode = gridView1.GetRowCellValue(0, gridView1.Columns["Item Code"]).ToString();
          }
     }
