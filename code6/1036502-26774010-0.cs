    public static UserObject FindContactBySip(string sip)
    {
        return UserList.FirstOrDefault(u => u.HasSip(sip));
    }
    private static void InitFindUsersInAD()
    {
        PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
        var user = new UserPrincipal(ctx);
        user.Name = "*";
        var searcher = new PrincipalSearcher(user);
        var result = searcher.FindAll();
        var sipList = new List<string>();
        UserList = new List<UserObject>();
        foreach (var res in result)
        {
            var underlying = (DirectoryEntry)res.GetUnderlyingObject();
            string email = string.Empty, phone = string.Empty, policies = string.Empty;
            foreach (var keyval in underlying.Properties.Values)
            {
                var kv = keyval as System.DirectoryServices.PropertyValueCollection;
                if (kv != null && kv.Value is string)
                {
                    if (kv.PropertyName.Equals("msRTCSIP-PrimaryUserAddress"))
                    {
                        email = (kv.Value ?? string.Empty).ToString();
                    }
                    else if (kv.PropertyName.Equals("msRTCSIP-Line"))
                    {
                        phone = (kv.Value ?? string.Empty).ToString();
                    }
                    else if (kv.PropertyName.Equals("msRTCSIP-UserPolicies"))
                    {
                        policies = (kv.Value ?? string.Empty).ToString();
                    }
                }
            }
            if (!string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(email))
            {
                var userobj = new UserObject(email, phone, policies);
                UserList.Add(userobj);
            }
        }
    }
