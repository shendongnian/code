        Dictionary<Control, int> RequiredControlPrivilege;
    
        foreach(var item in _items)
        {
            if(RequiredControlPrivilege.Contains(item)
            {
                item.Enabled = RequiredControlPrivilege[item] >= CurrentLevel
            }
            else
            {
                item.Enabled = false //Default to false or change to true...
            }
        }
