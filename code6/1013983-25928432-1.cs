     public DataTable show(string query)
            {
          con = new sqlConnection(@"ConnectionString");
          con.open();
          cmd= new sqlcommand(query,con);
          sqldataadapter da = new sqldataadapter();
          Datatable dt=new DataTable();       
          da.fill(dt);    
          return dt;
           }
