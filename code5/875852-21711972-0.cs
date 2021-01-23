    public static void TrimPQueue(PriorityQueue<int> paraQueue, int newSize)
    {
        if (newSize >= paraQueue.Count)
            return ;
        for (int i = 1; i < newSize + 1; i++)
            paraQueue.Dequeue();
    } 
