    IReadableRepo
    {
        Data Read();
    }
    
    IUpdatableRepo : IReadableRepo
    {
        void Update();
    }
