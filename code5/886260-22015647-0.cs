            public void Do()
            {
                var task = StartTask(500);
                var array = new[] {1000, 2000, 3000};
            //GetData also takes some time.
            foreach (var data in array)
            {
                if (task.IsCompleted)
                {
                    task = StartTask(data);
                }
                else
                {
                    task.Wait();
                    task = StartTask(data);
                }
            }
        }
        private Task StartTask(int data)
        {
            var task = new Task(DoSmth, data);
            task.Start();
            return task;
        }
        private void DoSmth(object time)
        {
            Thread.Sleep((int) time);
        }
