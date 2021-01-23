    //EF 5.0.0.
    private tables entities = new Tables();
    private string validFrom; //try with date as well, should work
    private int id;
    using (OracleBulkCopy bulkCopy = new OracleBulkCopy(applicationContext.GetConnection(CrmContext.ConnectionEnum.CrmDatabase)))
    {
                bulkCopy.DestinationTableName = "TABLE";
                bulkCopy.BulkCopyTimeout = 180;
                bulkCopy.WriteToServer(dataTable);
                bulkCopy.Close();
    }
    //this is a workaroud due to error in Oracle DataAccess Driver
    //look at the
    entities.Database.ExecuteSqlCommand("UPDATE TABLE SET DATE_FROM = TO_DATE(:p0,'DD.MM.YYYY.') WHERE ID = :p1", validFrom, id);
    entities.SaveChanges();
