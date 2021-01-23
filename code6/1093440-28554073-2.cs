    // OrderUtil.UpdateSomething function
    public static void UpdateSomething(Order entity)
    {
        lock (padlock)
        {
            //modify the padLock or you need to ensure padLock does not change by other threads while being processed inside this block of code.
        }
    }
