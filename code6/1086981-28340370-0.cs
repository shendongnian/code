    itemList.AsParallel().ForAll((item) =>
    {
        Logger.Log("Processing item ...");
        ProcessItem(item);
    });
