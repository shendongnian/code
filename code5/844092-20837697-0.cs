    var rows = connection.Query("select 1 A, 2 B union all select 3, 4");
    
    ((int)rows[0].A).IsEqualTo(1);    
    ((int)rows[0].B).IsEqualTo(2);    
    ((int)rows[1].A).IsEqualTo(3);   
    ((int)rows[1].B).IsEqualTo(4);
