    public string Error
    {
        get { return null; }
    }
    public string this[string propertyName]
    {
        get { return GetValidationError(propertyName); }
    }
    private static readonly string[] ValidatedProperties = { "GroupName", "ParentId", "NatureOfGroupId" };
    public bool IsValid
    {
        get
        {
            foreach (string property in ValidatedProperties)
            {
                if (GetValidationError(property) != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
    private string GetValidationError(string propertyName)
    {
        string error = null;
        switch (propertyName)
        {
            case "GroupName":
                bool _IsDuplicateGroupName;
                using (MunimPlusContext context = new MunimPlusContext())
                {
                    _IsDuplicateGroupName = context.GroupSet.Any(x => x.GroupName.ToLower() == GroupName.ToLower());
                }
                if (String.IsNullOrWhiteSpace(GroupName))
                {
                    error = "Group Name cannot be Empty.";
                }
                else if (_IsDuplicateGroupName)
                {
                    error = "Duplicate Group Name. Please choose a unique Group Name.";
                }
                break;
            case "ParentId":
                if (ParentId == null)
                {
                    error = "Please select Under Group under which " + (GroupName == null ? "this" : GroupName) + " Group will appear.";
                }
                else if (ParentId <= 0)
                {
                    error = "Please select a valid GroupName from the list.";
                }
                break;
            case "NatureOfGroupId":
                Group _PrimaryGroup;
                using (MunimPlusContext context = new MunimPlusContext())
                {
                    _PrimaryGroup = context.GroupSet.Where(x => x.GroupName == "Primary").FirstOrDefault();
                }
                if (_PrimaryGroup.GroupId == ParentId)
                {
                    if (NatureOfGroupId == null)
                    {
                        error = "Please select the Nature of Group.";
                    }
                    else if (NatureOfGroupId <= 0)
                    {
                        error = "Please select a valid Nature of Group from the list.";
                    }
                }
                break;
        }
        return error;
    }
