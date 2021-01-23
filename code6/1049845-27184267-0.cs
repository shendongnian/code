    /// <summary>
    /// escapes a literal string so it can be inserted using sql
    /// </summary>
    /// <param name="sqlString">the string to be escaped</param>
    /// <returns>the escaped string</returns>
    public string escapeSQLString(string sqlString)
    {
    	// replace backslash "\" by double backslash "\\"
    	string escapedString = sqlString.Replace(@"\",@"\\");
    	// replace the single qoutes "'" by double single quotes "''"
    	escapedString = escapedString.Replace("'","''");
    	return escapedString;
    }
