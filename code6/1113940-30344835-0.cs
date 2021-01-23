    static void Main(string[] args)
    {
        GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        watcher.StatusChanged += (sender, e) =>
        {
            Console.WriteLine("new Status : {0}", e.Status);
        };
        watcher.PositionChanged += (sender, e) =>
        {
            Console.WriteLine("position changed. Location : {0}, Timestamp : {1}",
                e.Position.Location, e.Position.Timestamp);
        };
        if(!watcher.TryStart(false, TimeSpan.FromMilliseconds(5000)))
        {
             throw new Exception("Can't access location"); 
        }
        Console.ReadLine();
    }
