    static void Main(string[] args)
    {
        String location = @"DTS.Old\SomeDTSPackage.dts";
        DTS.Package pkg = new DTS.Package();
        DTS.Task task;
        DTS.DataPumpTask2 dataPumpTask;
        DTS.Transformation transform;
        DTS.Column source;
        DTS.Column destination;
        pkg.LoadFromStorageFile(location, null, null, null, null, null);
        Console.WriteLine("{0}", pkg.Name);
        Console.WriteLine("  TASKS");
        for (Int32 tsk = 1; tsk <= pkg.Tasks.Count; tsk++)
        {
            if (pkg.Tasks.Item(tsk).CustomTaskID == "DTSDataPumpTask")
            {
                dataPumpTask = (DTS.DataPumpTask2)pkg.Tasks.Item(tsk).CustomTask;
                Console.WriteLine("    TRANSFORMS");
                for (Int32 trans = 1; trans <= dataPumpTask.Transformations.Count; trans++)
                {
                    transform = dataPumpTask.Transformations.Item(trans);
                    for (Int32 col = 1; col <= transform.SourceColumns.Count && col <= transform.DestinationColumns.Count; col++)
                    {
                        source = transform.SourceColumns.Item(col);
                        destination = transform.DestinationColumns.Item(col);
                        Console.WriteLine("      {0} -> {1}", source.Name.PadRight(15, ' '), destination.Name);
                    }
                }
            }
        }
        Console.ReadKey(true);
    }
