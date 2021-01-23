    public bool CheckPhoneNumberExist(string newPhoneNumber)
    {
        LP = new LPEntities();
        var phoneList = (from act in LP.Accounts
                         select act).ToList();
        foreach (string phoneNumber in phoneList)
            Add(phoneNumber);
        return Add(newPhoneNumber);
    }
    private HashSet<string> _uniquePhoneNumbers = new HashSet<string>();
    public bool Add(string phoneNumber)
    {
        // Only use Regex if necessary
        if (!IsNumeric(phoneNumber))
            phoneNumber = RemoveNonNumericCharacters(phoneNumber);
        // Returns false if string already exists in HashSet
        return !_uniquePhoneNumbers.Add(phoneNumber);
    }
    
    private static readonly char[] _forbiddenChars = new char[] { ',', '.', '.', ' ', '+', '-' };
    
    private static bool IsNumeric(string s)
    {
        foreach(char c in _forbiddenChars)
            if(s.IndexOf(c) >= 0)
                return false;
    
        return true;
    }
    
    private static string RemoveNonNumericCharacters(string s)
    {
        return Regex.Replace(s, "[^0-9]", "");
    }
