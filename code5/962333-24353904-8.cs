    [Setup]
    public void Setup()
    {
        if (!CreateEntity())
        {
            throw new Exception("Failed to create entity");
        }
    }
