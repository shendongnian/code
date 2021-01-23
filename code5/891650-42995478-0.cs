      public List<object[]> RunSql(string sqlString)
      {
          var lstRes = new List<object[]>();
          var stQuery = SQLite3.Prepare2(fieldStrikeDatabase.Connection.Handle, sqlString);
           try
           {
               var colLenght = SQLite3.ColumnCount(stQuery);
               while (SQLite3.Step(stQuery) == SQLite3.Result.Row)
               {
                   var obj = new object[colLenght];
                   lstRes.Add(obj);
                   for (int i = 0; i < colLenght; i++)
                   {
                       var colType = SQLite3.ColumnType(stQuery, i);
                       switch (colType)
                       {
                           case SQLite3.ColType.Blob:
                               obj[i] = SQLite3.ColumnBlob(stQuery, i);
                               break;
                           case SQLite3.ColType.Float:
                               obj[i] = SQLite3.ColumnDouble(stQuery, i);
                               break;
                           case SQLite3.ColType.Integer:
                               obj[i] = SQLite3.ColumnInt(stQuery, i);
                               break;
                           case SQLite3.ColType.Null:
                               obj[i] = null;
                               break;
                           case SQLite3.ColType.Text:
                               obj[i] = SQLite3.ColumnString(stQuery, i);
                               break;
                       }
                   }
               }
               return lstRes;
           }
           catch (Exception)
           {
               return null;
           }
           finally
           {
               SQLite3.Finalize(stQuery);
           }
       }
