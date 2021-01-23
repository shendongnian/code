    public static string testingString(string s1, string s2, bool isAllowed, bool isAdmin, bool isCustomer){
        string result = string.Format("{0}/{1}", s1, s2);
        if (isAllowed) 
        {
            result += "/Allowed";
        }
        if (isAdmin) 
        {
            result += "/admin";
        }
        if (isCustomer) 
        {
            result += "/customer";
        }
        return result;
    }
