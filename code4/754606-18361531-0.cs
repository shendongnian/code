              DataView dv=(DataView) from test in db.Tests
                                         select new
                                         {
                                             testId= test.TestId,
                                             courseName = test.Course.Name,
                                             onDate = test.OnDate,
                                             lastRegisterDate = test.LastRegisterDate
                                         };
             gridAllTests.DataSource = dv;
    
            DataTable dt = new DataTable();      
     
            DataSourceSelectArguments args = new DataSourceSelectArguments();
     
            DataView dv = new DataView();
            dv = (DataView)dv.Select(args);// This SqlDataSourceObject means your sql query return object ,like dataset or dataview, etc
     
            dt = dv.ToTable();
