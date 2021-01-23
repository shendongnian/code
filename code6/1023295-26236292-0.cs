     DataAdapter adapter=new DataAdapter(SqlCommand,SqlConn);
     DataTable tbl=new Datatable();
     adapter.Fill(tbl);
     GridView1.DataSource=tbl;
     GridView1.DataBind();//This line is missing in your code
