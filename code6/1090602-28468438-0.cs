        public void Stop()
        {
            runFlag = false;
            if (taskList.Count > 0)
            {
                // wait
                Task.WaitAll(taskList.ToArray());
                taskList = new List<Task>();
            }
            else
            {
                // no wait, great.
            }
        }
