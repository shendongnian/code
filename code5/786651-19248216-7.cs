    public static class MigrationExtensions
    {
        internal static string DeleteSqlFormat
        {
            //I also hard delete anything deleted more than a day ago in the same table
            get { return "DELETE FROM {0} WHERE IsDeleted = 1 AND DATEADD(DAY, 1, DeletedAt) < GETUTCDATE(); UPDATE {0} SET IsDeleted = 1, DeletedAt = GETUTCDATE() WHERE ID = @ID;"; }
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
 
