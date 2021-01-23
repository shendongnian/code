    sqlcmd = sqlcon.CreateCommand();
     
    string[] words = textBox1.Text.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
    StringBuilder query = new StringBuilder("SELECT * FROM T1 WHERE 1 = 1");
     
    for (int index = 0; index < words.Length; index++)
    {
        string wordToFind = words[index];
        string parameterName = "@word" + index;
        sqlcmd.Parameters.AddWithValue(parameterName, "%" + wordToFind + "%");
        query.AppendFormat(" AND (EnglishWord Like {0} OR EnglishDesc Like {0} OR ArabicWord Like {0} OR ArabicDesc Like {0})", parameterName);
    }
     
    sqlcmd.CommandText = query.ToString();
