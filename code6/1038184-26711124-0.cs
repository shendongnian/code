    public string EscapeQuotesMySql(string str)
            {
    
                string retVal = System.String.Empty;
    
                if (!System.String.IsNullOrEmpty(str))
                {
    
                    // replace special quotes
    
                    retVal = str.Replace((char)8216, '\'');
    
                    retVal = retVal.Replace((char)8217, '\'');
    
                    // escapes for SQL
    
                    retVal = retVal.Replace(@"\", @"\\");
    
                    retVal = retVal.Replace(@"'", @"\'");
    
                }
    
                return retVal;
    
            }
