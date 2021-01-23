    public static void MyDataGrabbingClass<T>(MyModelCls Model) where T : class
    {
       using (SqlConnection conn = new SqlConnecrion(Config.ConnectionString)
       {
           conn.Open();
        
           string tableName = ...;
           string dateToColumnName = ...;
        
           // depending on how dateToColumnName is constructed, ensure it is not a SQL-injection risk
           if (tableName.Any(c => !char.IsLetterOrDigit(c))
               throw new ArgumentException("Invalid table name.");
           if (dateToColumnName.Any(c => !char.IsLetterOrDigit(c))
               throw new ArgumentException("Invalid column name.");
           // Query is a
           var results = conn.Query<T>("SELECT * FROM [" + tableName + "] WHERE [" + dateToColumnName + "] < @DateTo", new { DateTo = someDate });
           
           ...
    
       }
    }
