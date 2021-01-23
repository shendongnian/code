    public static string ValueOrEmpty(this object source) 
    {
         return source == null ? string.Empty : source.ToString();
    }
    var values = new[] { reader["legal1"],reader["legal2"],reader["legal3"] };
    LegalDesc = string.Join(" ", 
                            values.Select(x => x.ValueOrEmpty())
                                  .Where(x => x != string.Empty));
