    public Boolean RequestOverrideSuperUserCount(int count)
    {
        Boolean overrideAllowed = (null == users);
        if(overrideAllowed)
            SuperUserCount = count;
        return overrideAllowed;
    }
