    /// <summary>
    /// Waits for threads that are still being processed
    /// </summary>
    public static void WaitForThreads()
    {
        List<Thread> toRemove = new List<int>();
        int i = 0;
        foreach (Thread thread in threads)
        {
            i++;
            if (thread.IsAlive)
            {
                Debug.Print("waiting for {0} - {1} to end...", thread.Name, i);
                thread.Join();
            }
            else
            {
                toRemove.Add(thread);
            }
        }
        threads.RemoveAll(x => toRemove.Contains(x));
    }
