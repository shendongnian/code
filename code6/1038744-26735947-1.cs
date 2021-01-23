    // Corrected DeleteContact
    public void DeleteContact(int Id)
    {
        using (var dbConn = new SQLiteConnection(App.DB_PATH))
        {
            var existingvalue = dbConn.Query<historyTableSQlite>("select * from historyTableSQlite where Id =" + Id).FirstOrDefault();
            foreach(historyTableSQlite item in existingvalue)
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Delete(item);                                               
                });
            }
        }
    }
