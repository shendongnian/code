    static List<string> list1 = new List<string> { "A1", "A2", "A3", "A4", "A5" };
    static List<string> list2 = new List<string> { "B1", "B2", "B3", "B4", "B5" };
    static List<string> list3 = new List<string> { "C1", "C2", "C3", "C4", "C5" };
    // Add all lists to the array below.
    static List<string>[] lists = new[] { list1, list2, list3 };
    static AutoResetEvent[] waitHandles;
    static void Main(string[] args)
    {
        waitHandles = new AutoResetEvent[lists.Length];
        var threads = new Thread[lists.Length];
        for (int i = 0; i < lists.Length; i++)
        {
            // Initialize a wait handle and thread for each list.
            int threadIndex = i;
            waitHandles[i] = new AutoResetEvent(false);
            threads[i] = new Thread(new ThreadStart(() => show(threadIndex)));
            threads[i].Start();
        }
        // Signal first thread to start off process.
        waitHandles[0].Set();
        Console.ReadLine();
    }
    // Method run within each thread.
    static void show(int threadIndex)
    {
        // The index of the next thread to signal after printing each element.
        int nextThreadIndex = (threadIndex + 1) % lists.Length;
        // Iterate over all elements of current thread's list.
        foreach (string x in lists[threadIndex])
        {
            // Wait for turn of current thread.
            waitHandles[threadIndex].WaitOne();
            // Print one element.
            Console.Write(x + " ");
            // Signal next thread to proceed.
            waitHandles[nextThreadIndex].Set();
        }
        // Assume all lists are equal in length.
        // Otherwise, threads might need to keep signalling
        // even after printing all their elements.
    }
    
    // Output: A1 B1 C1 A2 B2 C2 A3 B3 C3 A4 B4 C4 A5 B5 C5
