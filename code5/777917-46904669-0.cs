        private List<Tuple<Task, CancellationTokenSource>> _parameterExtractionTasks = new List<Tuple<Task, CancellationTokenSource>>();
        /// <remarks>This method is asynchronous, i.e. it runs partly in the background. As this method might be called multiple times 
        /// quickly after each other, a mechanism has been implemented that <b>all</b> tasks from previous method calls are first canceled before the task is started anew.</remarks>
        public async void ParameterExtraction() {
            CancellationTokenSource newCancellationTokenSource = new CancellationTokenSource();
            // Define the task which shall run in the background.
            Task newTask = new Task(() => {
                // do some work here
                    }
                }
            }, newCancellationTokenSource.Token);
            _parameterExtractionTasks.Add(new Tuple<Task, CancellationTokenSource>(newTask, newCancellationTokenSource));
            /* Convert the list to arrays as an exception is thrown if the number of entries in a list changes while 
             * we are in a for loop. This can happen if this method is called again while we are waiting for a task. */
            Task[] taskArray = _parameterExtractionTasks.ConvertAll(item => item.Item1).ToArray();
            CancellationTokenSource[] tokenSourceArray = _parameterExtractionTasks.ConvertAll(item => item.Item2).ToArray();
            for (int i = 0; i < taskArray.Length - 1; i++) { // -1: the last task, i.e. the most recent task, shall be run and not canceled. 
                // Cancel all running tasks which were started by previous calls of this method
                if (taskArray[i].Status == TaskStatus.Running) {
                    tokenSourceArray[i].Cancel();
                    await taskArray[i]; // wait till the canceling completed
                }
            }
            // Get the most recent task
            Task currentThreadToRun = taskArray[taskArray.Length - 1];
            // Start this task if, but only if it has not been started before (i.e. if it is still in Created state). 
            if (currentThreadToRun.Status == TaskStatus.Created) {
                currentThreadToRun.Start();
                await currentThreadToRun; // wait till this task is completed.
            }
            // Now the task has been completed once. Thus we can recent the list of tasks to cancel or maybe run.
            _parameterExtractionTasks = new List<Tuple<Task, CancellationTokenSource>>();
        }
