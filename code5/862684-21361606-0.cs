    String Sql = "Select\r\n";
            for (int i = 1; i < strTableAndColumnName.Length; i++)
            {
                Sql += strTableAndColumnName[i] + ",\r\n";
            }
            Sql = Sql.Remove(Sql.Length - ",\r\n".Length) + 
                " from " + strTableAndColumnName[0];
