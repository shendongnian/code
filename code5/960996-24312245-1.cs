        DateTime commitTime = DateTime.Now; 
        foreach (var kvp in ItemsReceivedInstance)
        {
            ProcessInfo(commitTime, kvp);
        }
        ItemsReceivedInstance.Clear();
        ...
        private static void ProcessInfo(DateTime commitTime, KeyValuePair<int, Item> kvp)
        {
            // put item into persistent storage and perform other processing...
        }
