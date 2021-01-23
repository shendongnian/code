    public static void Main(string[] args)
    {
        Task.Run(() => EntitiesNew.InitializeDatabaseConnection()); //Assumes you put the function inside the EntitiesNew class
    
        Application.Run(new Form1());
    }
