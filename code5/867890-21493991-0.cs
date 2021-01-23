    public Consumer()
    {
        Task.Run(() => {
            Mutex m = Mutex.OpenExisting("Global\\m");
            m.WaitOne();
            Console.WriteLine("Done");
        });
    }
