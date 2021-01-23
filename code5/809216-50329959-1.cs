    public static T GetRootMasterPage<T>(MasterPage master) where T : MasterPage
    {
        if (master != null)
        {
            if (master.Master == null) // We've found the root
            {
                if (master is T)
                {
                    return master as T;
                }
                else
                {
                    throw new Exception($"GetRootMasterPage<T>: Could not find MasterPage of type {typeof(T)}");
                }
            }
            else // We're on a nested master
            {
                return GetRootMasterPage<T>(master.Master);
            }
        }
        return null;
    }
