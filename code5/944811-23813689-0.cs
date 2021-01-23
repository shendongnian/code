    long num = 100;
    Task one;
    {
        // Nothing can change copyOfNum!
        long copyOfNum = num;
        one = Task.Factory.StartNew(() => doWork(copyOfNum));
    }
