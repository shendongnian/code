    private void TaskCancelationCallBack(System.Threading.Tasks.Task task)
    {
      if (task.Status == System.Threading.Tasks.TaskStatus.Canceled)
      {
             //Canceled
      } 
    }
