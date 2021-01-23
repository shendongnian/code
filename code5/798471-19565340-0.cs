    using(MyDataContext db = new MyDataContext(strConnectionString))
     {
        if (db.DatabaseExists() == false)
          {
             db.CreateDatabase();
          }
        
       if(db.Table1.Count() == 0) MessageBox.Show("Table is empty");
    
     }
