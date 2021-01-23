    public List<string> SetRoles(ProfileTypeFlag role)
    {    
        var result = new List<string>();
        
        foreach (ProfileTypeFlag r in Enum.GetValues(typeof(ProfileTypeFlag)))
        {
            if (role.HasFlag(r) && r != ProfileTypeFlag.None) 
            {
                result.Add(r.ToString());
                role &= ~r;
            }
        }
    
        return result;
    }
