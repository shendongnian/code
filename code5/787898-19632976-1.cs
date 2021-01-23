    foreach(AssignmentData d in myDictionary.Values)
    {
        String parentKey = GetParentLDAPKey(d.AssignmentLDAPHierarchical);
        if (myDictionary.ContainsKey(parentKey))
        {
            myDictionary(parentKey).children.Add(d);
        }
        else
        {
            UserOUCollection.Add(d);
        }
    }
