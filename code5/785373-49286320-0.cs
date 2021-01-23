    using Microsoft.EntityFrameworkCore;
    using System.Data.Common;
    namespace TerminalInventory
    {
        public static class ExtensionMethods
        {
            public static bool TestConnection(this DbContext context)
            {
                DbConnection conn = context.Database.GetDbConnection();
    
                try
                {
                    conn.Open();   // Check the database connection
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
