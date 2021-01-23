    Dictionary<string, Queue<string>> messageQueue = new Dictionary<string, Queue<string>>();
    void AddMessage(string userName, string message)
    {
        Queue<string> queue;
        if (!messageQueue.TryGetValue(userName, out queue))
        {
            queue = new Queue<string>();
            messageQueue.Add(userName, queue);
        }
        queue.Enqueue(message);
        while (queue.Count > 5)
            queue.Dequeue();
    }
    void RemoveUser(string userName)
    {
        messageQueue.Remove(userName);
    }
