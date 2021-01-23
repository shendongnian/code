    static List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
    static List<int> list2 = new List<int> { 6, 7, 8, 9, 10 };
    static List<int> list3 = new List<int> { 11, 12, 13, 14, 15 };
    static List<int>[] lists = new[] { list1, list2, list3 };
    static List<AutoResetEvent> waitHandles =
        lists.Select(_ => new AutoResetEvent(false)).ToList();
    static void Main(string[] args)
    {
        var threads = lists.Select((list, threadIndex) =>
            new Thread(new ThreadStart(() => show(threadIndex)))).ToList();
        threads.ForEach(t => t.Start());
        waitHandles[0].Set();
        Console.ReadLine();
    }
    static void show(int threadIndex)
    {
        int nextThreadIndex = (threadIndex + 1) % lists.Length;
        foreach (int x in lists[threadIndex])
        {
            waitHandles[threadIndex].WaitOne();
            Console.Write(x + " ");
            waitHandles[nextThreadIndex].Set();
        }
    }
