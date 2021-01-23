    protected virtual void OnRecordFound(T record)
    {
        // Derived classes will handle "event" here
    }
    public void Find()
    {
        T record = FindRecordCore();
        if (record != default(T))
            OnRecordFound(record);
    }
