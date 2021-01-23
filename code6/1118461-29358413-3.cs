    private static int GetEstimatedWaitTime(Queue<int> currentQueue, int numServers)
    {
        int waitTime = 0;
        // Short-circuit if there are more servers than items in the queue
        if (currentQueue.Count < numServers) return waitTime;
        // Create a copy of the queue so we can dequeue from it
        var remainingItems = new Queue<int>();
        foreach (var item in currentQueue)
        {
            remainingItems.Enqueue(item);
        }
        // Grab an item for each server
        var itemsBeingServiced = new List<int>();
        for (int i = 0; i < numServers; i++)
        {
            itemsBeingServiced.Add(remainingItems.Dequeue());
        }
        do
        {
            // Get the shortest item left, increment our wait time, and adjust other items
            itemsBeingServiced.Sort();
            var shortestItem = itemsBeingServiced.First();
            waitTime += shortestItem;
            itemsBeingServiced.RemoveAll(item => item == shortestItem);
            for (int i = 0; i < itemsBeingServiced.Count; i++)
            {
                itemsBeingServiced[i] = itemsBeingServiced[i] - shortestItem;
            }
            // Add more items for available servers if there are any
            while (itemsBeingServiced.Count < numServers && remainingItems.Any())
            {
                itemsBeingServiced.Add(remainingItems.Dequeue());
            }
        } while (itemsBeingServiced.Count >= numServers);
        return waitTime;
    }
