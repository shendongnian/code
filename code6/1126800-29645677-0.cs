    public class MainViewModel
    {
        public MainViewModel()
        {
            this.Title = "Main view";
        }
        public async Task StartLongOperationAsync()
        {
            this.IsLoading = true;
            await Task.Run(() =>
	        {
		        //do work here
		    });
            this.IsLoading = false;
        }
    }
