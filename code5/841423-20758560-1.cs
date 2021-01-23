    static readonly object Sync = new object();
    public static void IncrementId()
    {
        Monitor.Enter(Sync);
        Console.WriteLine(Properties.Settings.Default.Id);
        Properties.Settings.Default.Id++;
        Properties.Settings.Default.Save();
        Console.WriteLine(Properties.Settings.Default.Id);
        Monitor.Exit(Sync);
    }
