    public bool AddParameter(string pattern, SqlDbType parameterType, int length, string value)
    {
        //do your stuff
        return AddParameter<string>(pattern, parameterType, length, updatedValue);
    }
    public bool AddParameter<T>(string pattern, SqlDbType parameterType, int length, T value)
    {
    }
