    public class StackWork : ViewModelBase
    {
        private class MyHandler
        {
            private async Task<string> GetDataAsync(string result)
            {
                return await Task<string>.Run(() =>
                    {
                        Thread.Sleep(5000);
                        return result;
                    });
            }
            public async Task<string> GetData1Async()
            {
                return await GetDataAsync("Data1");
            }
            public async Task<string> GetData2Async()
            {
                return await GetDataAsync("Data2");
            }
            public async Task<string> GetData3()
            {
                return await GetDataAsync("Data3");
            }
        }
        private bool IsBusy { get; set; }
        private string _message = "";
        public string BusyMessage
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged("BusyMessage"); }
        }
        private MyHandler blHandler = new MyHandler();
        private Task<string> getDeviceInfoTask;
        private string result1 { get; set; }
        private string result2 { get; set; }
        private string result3 { get; set; }
        public StackWork()
        {
            getDeviceInfoTask = Task<string>.Run(() =>
                {
                    return ("device info");
                });
        }
        public async void StartTest(object obj)
        {
            try
            {
                this.IsBusy = true;
                this.BusyMessage = "Init...";
                await Task.Delay(7000);
                var getData1Task = /*this*/await/*was missing*/ this.blHandler.GetData1Async();
                this.BusyMessage = "Retreiving data...";
                //assuming this was Task.Run, put that in constructor
                this.result1 = getDeviceInfoTask/*this*/.Result/*was missing*/;
                this.result2 = await this.blHandler.GetData2Async();
                this.BusyMessage = "Searching...";
                //This was a little confusing because the name doesn't imply it is 
                //async, but it is awaited
                this.result3 = await this.blHandler.GetData3();
            }
            finally
            {
                this.IsBusy = false;
                this.BusyMessage = string.Empty;
            }
        }
    }
