    RunSqlTransaction(CommonCode.CreateTableDescription("__MigrationHistory", "Database Version History Table - Administration User Only"));
        	
        RunSqlTransaction(CommonCode.CreateColumnDescription("__MigrationHistory", "ContextKey", "Defining the Migration Context"));
        		RunSqlTransaction(CommonCode.CreateColumnDescription("__MigrationHistory", "MigrationId", "Unique Migration Identifier"));
        		RunSqlTransaction(CommonCode.CreateColumnDescription("__MigrationHistory", "Model", "Binary of the SQL Change Model"));
        		RunSqlTransaction(CommonCode.CreateColumnDescription("__MigrationHistory", "ProductVersion", "Version of The Database Change"));
