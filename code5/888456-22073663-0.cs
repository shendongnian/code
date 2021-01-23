    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
    csb.DataSource = "SHIRWANIPC";
    csb.InitialCatalog = "...";
    ...
    SqlConnection conn = new SqlConnection(csb.ConnectionString);
