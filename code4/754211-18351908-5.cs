    public static void Main(string[] args)
    {
        //Assumes you put the function inside the EntitiesNew class
        Task.Run(() => EntitiesNew.InitializeDatabaseConnection()); 
    
        Application.Run(new Form1());
    }
