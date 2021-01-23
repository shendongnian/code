    string day = DateTime.Now.ToShortDateString();
    string time = DateTime.Now.ToShortTimeString();
    string test = "insert into timeclock(day, time) values (@p1, @p2)";
                    
    List<SqlParameter> parameters = new List<SqlParameter>();
    parameters.Add(new SqlParameter("@p1", day));
    parameters.Add(new SqlParameter("@p2", time));
    
    db.Database.ExecuteSqlCommand(test, parameters.ToArray());
