    /// <summary>
    /// escapes a literal string so it can be inserted using sql
    /// </summary>
    /// <param name="sqlString">the string to be escaped</param>
    /// <returns>the escaped string</returns>
    public string escapeSQLString(string sqlString)
    {
    	string escapedString = sqlString;
    	switch ( this.repositoryType) 
	    {
    		case RepositoryType.MYSQL:
    		case RepositoryType.POSTGRES:
		    	// replace backslash "\" by double backslash "\\"
		    	escapedString = escapedString.Replace(@"\",@"\\");
			break;
    	}
    	// ALL DBMS types: replace the single qoutes "'" by double single quotes "''"
    	escapedString = escapedString.Replace("'","''");
    	return escapedString;
    }
