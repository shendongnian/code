        // Method that makes calls to fetch and write data.
        public async Task DoStuff()
        {
            Task currTask = null;
            object somedata = await FetchData();
            while (somedata != null)
            {
                // Wait for previous task.
                if (currTask != null)
                    Task.WaitAny(currTask);
                currTask = WriteData(somedata);
                somedata = await FetchData();
            }
        }
        // Whatever method fetches data.
        public Task<object> FetchData()
        {
            var data = new object();
            return Task.FromResult(data);
        }
        // Whatever method writes data.
        public Task WriteData(object somedata)
        {
            return Task.Factory.StartNew(() => { /* write data */});
        }
