    static readonly object Sync = new object();
    public static void IncrementId()
    {
        lock(Sync)
        {
            Console.WriteLine(Properties.Settings.Default.Id);
            Properties.Settings.Default.Id++;
            Properties.Settings.Default.Save();
            Console.WriteLine(Properties.Settings.Default.Id);
        }
    }
