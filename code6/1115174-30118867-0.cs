    /// <summary>
    ///    Regular expression implementation of the the JavaScript unescape method
    /// </summary>
    /// <param name="sqlValue">A JavaScript escaped string</param>
    /// <returns>Unescaped representation of the input string</returns>
    [SqlFunction(DataAccess = DataAccessKind.None, IsDeterministic = true)]
    public static SqlString Unescape(SqlString sqlValue)
    {
        if (sqlValue.IsNull)
        {
            return new SqlString("");
        }
        else
        {
            string buffer = sqlValue.Value;
    
            //replacing "Unicode" characters
            buffer = Regex.Replace(buffer, @"%U([0-9A-F]{4})", match => ((char)int.Parse(match.Groups[1].Value, NumberStyles.HexNumber)).ToString(), RegexOptions.IgnoreCase);
            //replacing "ASCII" character
            buffer = Regex.Replace(buffer, @"%([0-9A-F]{2})", match => ((char)int.Parse(match.Groups[1].Value, NumberStyles.HexNumber)).ToString(), RegexOptions.IgnoreCase);
    
            return new SqlString(buffer);
        }
    }
