        public async Task DoSomethingAsync()
        {
            Task<string> theTask = DelayAsync();
            try
            {
                string result = await theTask;
                Debug.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
            }
            Debug.WriteLine("Task IsCanceled: " + theTask.IsCanceled);
            Debug.WriteLine("Task IsFaulted:  " + theTask.IsFaulted);
            if (theTask.Exception != null)
            {
                Debug.WriteLine("Task Exception Message: "
                    + theTask.Exception.Message);
                Debug.WriteLine("Task Inner Exception Message: "
                    + theTask.Exception.InnerException.Message);
            }
        }
        private async Task<string> DelayAsync()
        {
            await Task.Delay(100);
            // Uncomment each of the following lines to 
            // demonstrate exception handling. 
            //throw new OperationCanceledException("canceled");
            //throw new Exception("Something happened.");
            return "Done";
        }
