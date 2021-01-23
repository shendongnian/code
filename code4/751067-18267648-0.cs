    void ProcessLog()
    {
        CsvWriter csv = new CsvWriter(@"C:\test.csv");
        
        List<Bailleur> bailleurs = DataLoader.LoadBailleurs();
    
        const int MAX_BAG_SIZE = 500;
        BlockingCollection<string> log = new BlockingCollection<string>(new ConcurrentBag<string>(), MAX_BAG_SIZE);
    
        int i = 0;
        
        var taskWriteToLog = new Task(() =>
        {
            // Consume the items in the bag, no need for sleeps or poleing, When items are available it runs, when they are not it blocks.
            foreach(string item in log.GetConsumingEnumerable())
            {
                csv.WriteLine(item);
            }
        });
        
        taskWriteToLog.Start();
        
        Parallel.ForEach(bailleurs, s1 =>
        {
            //Snip... You can switch to BlockingCollection without any changes to this section of code.
        });
        
        log.CompleteAdding(); //lets anyone using GetConsumingEnumerable know that no new items are comming so you can leave the foreach loops.
    }
