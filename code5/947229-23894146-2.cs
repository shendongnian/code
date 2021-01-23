    BindingSource bS1, bS2, bS3;
    ..
    ..    
    ..
    ..    
    dt = new DataTable();
    dt.Load(reader);
    bS1 = new BindingSource();
    bS1.DataSource = dt; 
    bS2 = new BindingSource();
    bS2.DataSource = dt; 
    bS3 = new BindingSource();
    bS3.DataSource = dt;
    ..
    ddl1.DataSource = bS1 ;
    ddl2.DataSource = bS2 ;
    ddl3.DataSource = bS3 ;
    ..
    ..
