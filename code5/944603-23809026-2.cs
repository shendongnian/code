     SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
     DataTable sqlDt = new DataTable();
     sqlDa.Fill(sqlDt);
     //added 2 lines
     DataView dataView = new DataView(dataTable);
     dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(GridSortDirection);
     GridViewFoundations.DataSource = dataView;
     GridViewFoundations.DataBind();
