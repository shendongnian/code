    /* Omitted most INPC property declarations...kinda boring */
    public ICommand SetTaskDetailsFromCurrentTaskCommand { get { return new RelayCommand(SetTaskDetailsFromCurrentTask); } }
    public ICommand SetTaskDetailsFromTaskListCommand { get { return new RelayCommand<TaskScheduleSequenceDto>(async taskSelection => await SetTaskDetailsFromTaskList(taskSelection)); } }
    private bool _currentTaskSelected;
    public bool CurrentTaskSelected
    {
        get
        {
            return _currentTaskSelected;
        }
        set
        {
            Set(() => CurrentTaskSelected, ref _currentTaskSelected, value);
        }
    }
    private async Task SetTaskDetailsFromTaskList(TaskScheduleSequenceDto taskListSelection)
    {
        if (taskListSelection == null)
        {
            return;
        }
    
        var taskDetails = await _broker.RetrieveTaskDetails(taskListSelection.TaskId);
    
        TaskDetails = taskDetails;
        CurrentTaskSelected = false;
    }
    
    private void SetTaskDetailsFromCurrentTask()
    {
        TaskDetails = CurrentTask;
        TaskListSelection = null;
        CurrentTaskSelected = true;
    }
