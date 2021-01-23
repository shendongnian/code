    string sql = "The address4 is found in varchar ( 4 ) is a 4.";
    int indexOfVarchar = sql.IndexOf("varchar", StringComparison.OrdinalIgnoreCase);
    if (indexOfVarchar >= 0)
    { 
        indexOfVarchar += "varchar".Length;
        int indexOfBrace = sql.IndexOf("(", indexOfVarchar);
        if(++indexOfBrace > 0)
        {
            int indexOfEndBrace = sql.IndexOf(")", indexOfBrace);
            if (indexOfEndBrace >= 0)
            {
                sql = string.Format("{0}MAX{1}", 
                    sql.Substring(0, indexOfBrace), 
                    sql.Substring(indexOfEndBrace));
            }
        }
    }
