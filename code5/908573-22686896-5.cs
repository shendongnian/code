    private ITask<Task1Data> task1;
    public Consumer(ITask<Task1Data> task1) {
        this.task1 = task1;
    }
    public void DoTask(string arg, int arg1)
    {
        task1.Handle(new Task1Data { Arg = arg, Arg1 = arg1 });
    }
