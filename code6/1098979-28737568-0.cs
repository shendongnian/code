    List<Tuple<Task, Boolean[]>> lst = Enumerable.Range(0, _tasks.Count).Select(ix => Tuple.Create(_tasks[ix], _tasksAllowedProcessingUnits[ix])).ToList();
    lst.Sort((p, q) => p.Item1.CompareTo(q.Item1));
    for (int i = 0; i < _tasks.Count; i++) {
        _tasks[i] = lst[i].Item1;
        _tasksAllowedProcessingUnits[i] = lst[i].Item2
    }
