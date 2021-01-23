     private void SelectFromDb()
        {   
        SQLite.SQLiteConnection conn = new SQLiteConnection(DB_PATH);
        //conn.CreateTable<Product>();
        //InsertSampleinDB(conn);
        List<Product> myProducts = conn.Table<Product>().ToList().Where(x => x.Name.Length > 10);
        }
