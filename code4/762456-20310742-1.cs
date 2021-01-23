    readonly Task _initializeDatabaseTask = InitializeDatabase();
    async Task Worker1()
    {
        await _initializeDatabaseTask;
        // Do what you need after database is initialized
    }
    async Task Worker2()
    {
        await _initializeDatabaseTask;
        // Do what you need after database is initialized
    }
    static async Task InitializeDatabase()
    {
        // Initialize your database here
    }
