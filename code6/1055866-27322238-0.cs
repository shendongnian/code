            //permanently change DBConfig Fields 
            DBConfig.SetGLConnection("ziad-pc", "GLTest", "admin", "3343402"); 
            DBConfig.ChangeDatabase(EgxDataType.GLConnection,"GLTest");
             // here 
            DataAccess.CommitDatabaseChanging(); //Retrieve Last Connection Data
