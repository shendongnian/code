    public static void Action(ThreadData threadData)
    {
        for (int i = 0; i < 100000; i++)
        {
            if (threadData.Mre.IsSet)
            {
                break;
            }
            Trace.WriteLine("I'm " + threadData.Pid);
        }
    }
