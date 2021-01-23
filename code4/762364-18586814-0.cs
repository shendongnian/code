    using System.Data.SqlServerCe;
    using System.IO;
    
    ...
    
    namespace SomeNamespace
    {
        public class SomeClass
        {
            public static void CreateDatabase(string connectionString)
            {
                using (var engine = new SqlCeEngine(connectionString))
                {
                    if (IsDatabaseExists(connectionString))
                        File.Delete(GetPathToDatabase(connectionString));
                    engine.CreateDatabase();
    
                    using (var conn = new  SqlCeConnection(connectionString))
                    {
                        conn.Open();
                        
                        var cmd = new SqlCeCommand(@"CREATE TABLE [Users](
                                            [ID] [int] IDENTITY(1,1) NOT NULL
                                            [Username] [nvarchar](128) NOT NULL
                                            CONSTRAINT [PK_Users] PRIMARY KEY NONCLUSTERED ([ID]))";
                        cmd.ExecuteNonQuery();
                        
                        cmd.CommandText = @"CREATE TABLE [UserAnswers](
                                            [ID] [int] IDENTITY(1,1) NOT NULL,
                                            [UserID] [int] NOT NULL,
                                            [Question] [nvarchar](256) NOT NULL,
                                            [Answer] [nvarchar](256) NOT NULL,
                                            CONSTRAINT [PK_UserAnswers] PRIMARY KEY NONCLUSTERED ([ID]))";
                        cmd.ExecuteNonQuery();
    
                        cmd.CommandText = @"ALTER TABLE [UserAnswers] ADD  CONSTRAINT [FK_UserAnswers_Users] FOREIGN KEY([UserID])
                                            REFERENCES [Users] ([ID])
                                            ON DELETE CASCADE";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
