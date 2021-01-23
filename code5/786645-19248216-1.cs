    public static class MigrationExtensions
    {
        internal static string DeleteSqlFormat
        {
            get { return "DELETE FROM {0} WHERE IsDeleted = 1; UPDATE {0} SET IsDeleted = 1 WHERE ID = @ID"; }
        }
        internal static void CreateDeleteProcedure(this DbMigration migration, string procName, string tableName)
        {
            migration.CreateStoredProcedure(
                            procName,
                            p => new
                            {
                                ID = p.Int(),
                            },
                            body:
                                string.Format(MigrationExtensions.DeleteSqlFormat, tableName)
                        );
        }
    }
 
