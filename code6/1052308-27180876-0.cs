    string dbPath = IO.Path.Combine(
               System.Reflection.Assembly.GetExecutingAssembly().Location,
               "access.mdb");
    string connectionString = String.Format(
               "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}",
               dbPath);
