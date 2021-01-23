    private void btnAddShots_Click(object sender, EventArgs e)
    {
        Action<Task> continuation = null;
        TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        int noOfShots = dataGridShots.Rows.Count - 1;
        int count = 0;
        // Note that the continuation delegate is chained, attaching itself as
        // the continuation for each successive task, thus achieving a looping
        // mechanism.
        continuation = task =>
        {
            if (count < noOfShots)
            {
                addTaskPair(dataGridShots.Rows[count].Cells[0].Value.ToString(), 
                    dataGridShots.Rows[count].Cells[1].Value.ToString(), 
                    dataGridShots.Rows[count].Cells[2].Value.ToString())
                    .ContinueWith(continuation, uiScheduler);
                count += 1;
            }
        }
        // Invoking the continuation delegate directly gets the ball rolling
        continuation(null);
    }
    private Task addTaskPair(string taskName, string taskDescription, string taskPriority)
    {
        try
        {
            TaskData trackingTask = new TaskData();
    
            trackingTask.content = taskName;
            trackingTask.description = taskDescription;
            trackingTask.priority = taskPriority; 
    
            string trackingJson = JsonConvert.SerializeObject(trackingTask);
            trackingJson = "{ \"todo-item\":" + trackingJson + " }";
    
            string url = teamworkURL + "/tasklists/" 
                + todoLists.todoLists[cmbTrackingList.SelectedIndex].id + "/tasks.json";
            // NOTE: must explicitly specify TaskScheduler.Default, because
            // the default scheduler in the context of a Task is whatever the
            // current scheduler is, which while executing a continuation would
            // be the UI scheduler, not TaskScheduler.Default.
            return Task.Factory.StartNew(() => postJSON(trackingJson, url),
                CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                .ContinueWith(task =>
                {
                    if (task.Exception != null)
                    {
                        // Task exceptions are wrapped in an AggregateException
                        debugMessage(task.Exception.InnerException.ToString());
                    }
                    else
                    {
                        string jsonResponse = task.Result;
                        // do something with jsonResponse?
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        catch (Exception e)
        {
            debugMessage(e.ToString());
        }
    }
