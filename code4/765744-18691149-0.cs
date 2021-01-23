    SqlCeDataReader reader = command.ExecuteReader();
    String typeName;
    String syntax;
    if(reader.Read()) {
        typeName = Convert.IsDBNull(reader["typeName"]) ? "" : Convert.ToString(reader["typeName "]);
        syntax = Convert.IsDBNull(reader["syntax"]) ? "" : Convert.ToString(reader["syntax "]);
    }
    KeywordTipTexts.Add(typeName, syntax);
    reader.Close();
