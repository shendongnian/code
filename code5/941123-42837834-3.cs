    using (MyDbContext db = new MyDbContext())
    {
        string query = db.Students.Where(o => o.Age > 20).ToString();
        
        DataTable dataTable = db.DataTable(query);
        
        ..
        
        DataTable dt = db.DataTable(
                             (  from o in db.Studets
                                where o.Age > 20
                                select o
                             ).ToString()
                        );
    }
