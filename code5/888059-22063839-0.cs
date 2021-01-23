    using (var dbContext = new db_ReadyEngine_MSSQL())
       {
         string nameOfField = "UserName";
    
         var table = dbContext.tbl_User;
         foreach (var x in table)
           {
             string fieldValue = typeof(x).GetProperty(nameOfField ).GetValue(x, null) as string;
           }
    }
