    namespace SQLite
    {
    public partial class SQLiteConnection 
    {
        public List<object[]> CustomQuery(string query, params object[] args)
        {
            var cmd = CreateCommand(query, args);
            return cmd.ExecuteCustomQuery();
        }
    }
	public partial class SQLiteCommand
    {
        public List<object[]> ExecuteCustomQuery()
        {
            if (SQLiteConnection.Trace)
            {
                Debug.WriteLine("Executing Query: " + this);
            }
            var stmt = Prepare();
            try
            {
                var colLenght = SQLite3.ColumnCount(stmt);
                var lstRes = new List<object[]>();
                while (SQLite3.Step(stmt) == SQLite3.Result.Row)
                {
                    var obj = new object[colLenght];
                    lstRes.Add(obj);
                    for (int i = 0; i < colLenght; i++)
                    {
                        var colType = SQLite3.ColumnType(stmt, i);
                        switch (colType)
                        {
                            case SQLite3.ColType.Blob:
                                obj[i] = SQLite3.ColumnBlob(stmt, i);
                                break;
                            case SQLite3.ColType.Float:
                                obj[i] = SQLite3.ColumnDouble(stmt, i);
                                break;
                            case SQLite3.ColType.Integer:
                                obj[i] = SQLite3.ColumnInt(stmt, i);
                                break;
                            case SQLite3.ColType.Null:
                                obj[i] = null;
                                break;
                            case SQLite3.ColType.Text:
                                obj[i] = SQLite3.ColumnString(stmt, i);
                                break;
                        }
                    }
                }
                return lstRes;
            }
            finally
            {
                SQLite3.Finalize(stmt);
            }
        }
    }
    }
