    public void RunTask(Func<DateTime, int> doWork)
    {
        _tasks = new Task<int>[_arguments.Count];
        for (int i = 0; i < _arguments.Count; i++)
        {
            var index = i;
            _tasks[i] = Task.Factory.StartNew<int>(() => doWork(_arguments[index]));
        }
    }
