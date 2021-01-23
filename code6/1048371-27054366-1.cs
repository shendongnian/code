    var taskWriteMergedFile = new Task(() =>
    {
        int recordCount = 0;
        foreach (var line in mergeData.GetConsumingEnumerable())
        {
            outputFile.WriteLine(line);
            ++recordCount;
            if (recordCount == 80,000)
            {
                // If you want to do something after 80,000 lines, do it here
                // and then reset the record count
                recordCount = 0;
            }
        }
    }, TaskCreationOptions.LongRunning);
