     DataTable datatable5 = new DataTable();
     datatable5.Columns.Add("ToolTip");
     datatable5.Columns.Add("Icons");
     datatable5.Columns.Add("ID");
     datatable5.Columns.Add("Number");
         
     for (int i = 0; i < 4; i++)
         tbl.Rows.Add(new object[] { String.Format("ToolTip{0}.", i),i,i,i});
      gridControl2.DataSource = dataTable5;
      gridView2.Columns["ToolTip"].Visible = false;
      gridView2.Columns["Icons"].Visible = false;
