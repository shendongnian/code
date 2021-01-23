    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    
    namespace GranadaCoder.PlaygroundConsole.SqlStuff
    {
        public class SqlPlayground
        {
    
            public static void EntryPointStuff()
            {
                string databaseName = "MyFirstDatabaseABC";
                string connectionString = string.Empty;
                string commandText = string.Empty;
                int returnValue = 0;
                string msg = string.Empty;
    
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder["Initial Catalog"] = "master";
                builder["integrated Security"] = true;
                builder["Server"] = @"MyMachine\MyInstance";
                connectionString = builder.ConnectionString;
    
    
                commandText = string.Format("IF EXISTS (Select * from sys.databases where name = N'{0}') DROP DATABASE [{0}]", databaseName);
                returnValue = RunACommand(connectionString, commandText);
                msg = string.Format("'{0}', {1}", returnValue, commandText);
                Console.WriteLine(msg);
    
                commandText = string.Format("IF NOT EXISTS (Select * from sys.databases where name = N'{0}') CREATE DATABASE [{0}]", databaseName);
                returnValue = RunACommand(connectionString, commandText);
                msg = string.Format("'{0}', {1}", returnValue, commandText);
                Console.WriteLine(msg);
    
                /* Change the Catalog */
                builder["Initial Catalog"] = databaseName;
                connectionString = builder.ConnectionString;
    
    
                commandText = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CodeCategory]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) 	BEGIN 		DROP TABLE [dbo].[CodeCategory] 	END ";
                returnValue = RunACommand(connectionString, commandText);
                msg = string.Format("'{0}', {1}", returnValue, commandText);
                Console.WriteLine(msg);
    
                commandText = "CREATE TABLE [dbo].[CodeCategory] ( 	  CodeCategoryKey			[smallint] not null 	, CodeCategoryName		varchar(64) not null  ) ";
                returnValue = RunACommand(connectionString, commandText);
                msg = string.Format("'{0}', {1}", returnValue, commandText);
                Console.WriteLine(msg);
    
    
                commandText = "INSERT INTO [dbo].[CodeCategory] ( 	  CodeCategoryKey		, CodeCategoryName	  ) Select 1001 , 'MyFirstCodeCategory' ";
                returnValue = RunACommand(connectionString, commandText);
                msg = string.Format("'{0}', {1}", returnValue, commandText);
                Console.WriteLine(msg);
    
                commandText = "Select Count(*) from [dbo].[CodeCategory]";
                returnValue = RunACommand(connectionString, commandText);
                msg = string.Format("'{0}', {1}", returnValue, commandText);
                Console.WriteLine(msg);
    
            }
    
    
    
    
            private static int RunACommand(string connectionString, string scriptText)
            {
    
                int returnValue = 0;
    
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(scriptText, sqlConnection))
                    {
                        returnValue = sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
    
                return returnValue;
            }
    
    
    
    
    
    
        }
    
    }
