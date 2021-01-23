    static void Main(string[] args)
    {
        SynchronizeThreeThreads();
        Console.ReadKey();
    }
    private static Barrier oneBarrier;
    private static Barrier twoBarrier;
    private static EventWaitHandle TwoDone = new AutoResetEvent(false);
    private static EventWaitHandle OneDone = new AutoResetEvent(false);
    private static void SynchronizeThreeThreads()
        {
            //Barrier hand off to each other (other barrier's threads do work between set and waitone)
            //Except last time when twoBarrier does not wait for OneDone
            int runCount = 2;
            int count = 0;
            oneBarrier = new Barrier(0, (b) => { Console.WriteLine("one done"); OneDone.Set(); TwoDone.WaitOne(); Console.WriteLine("one starting"); });
            twoBarrier = new Barrier(0, (b) => { Console.WriteLine("two done"); TwoDone.Set(); count++; if (count != runCount) { OneDone.WaitOne(); Console.WriteLine("two starting"); } });
            //Create tasks sorted into two groups
            List<Task> oneTasks = new List<Task>() { new Task(() => One(runCount)), new Task(() => One(runCount)), new Task(() => One(runCount)) };
            List<Task> twoTasks = new List<Task>() { new Task(() => Two(runCount)), new Task(() => TwoAlt(runCount)) };
            oneBarrier.AddParticipants(oneTasks.Count);
            twoBarrier.AddParticipants(twoTasks.Count);
            //Start Tasks. Ensure oneBarrier does work before twoBarrier
            oneTasks.ForEach(task => task.Start());
            OneDone.WaitOne();
            twoTasks.ForEach(task => task.Start());
            //Wait for all Tasks to finish
            oneTasks.ForEach(task => task.Wait());
            twoTasks.ForEach(task => task.Wait());
            Console.WriteLine("done");
        }
        static void One(int runCount)
        {
            for (int i = 0; i <= runCount; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("One " + i.ToString());
                oneBarrier.SignalAndWait();
            }
        }
        static void Two(int runCount)
        {
            for (int i = 0; i <= runCount; i++)
            {
                
                Thread.Sleep(500);
                Console.WriteLine("Two " + i.ToString());
                twoBarrier.SignalAndWait();
            }
        }
        static void TwoAlt(int runCount)
        {
            for (int i = 0; i <= runCount; i++)
            {
                 
                Thread.Sleep(10);
                Console.WriteLine("TwoAlt " + i.ToString());
                twoBarrier.SignalAndWait();
            }
        }
