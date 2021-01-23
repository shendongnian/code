     private static bool StateCharges_Exists(DataRow dr) {
     bool flag = false;
     Database pbkDB = DatabaseFactory.CreateDatabase("PbKConnectionString");
     DbCommand dbCommand = pbkDB.GetSqlStringCommand(string.Format(@"Select count(*) as cnt from   tblCtStateCharges where code = '{0}'", dr["Code"].ToString()));
     try {
        int count = (int)pbkDB.ExecuteNonQuery(dbCommand);
       flag = count > 0; 
     } catch (Exception ex) {
        Console.WriteLine(ex.ToString());
     }
     return flag;
}
