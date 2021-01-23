    public void makeUser(string username, string password, HashMethod method)
    {
        if (method == HashMethod.Plaintext)
        {
            ...
        }
        else if (method == HashMethod.Ldk)
        {
            ...
        }
        else if (method == HashMethod.MD5)
        {
            ...
        }
        else
        {
            throw new NotSupportedException("Unknown hash method");
        }
    }
